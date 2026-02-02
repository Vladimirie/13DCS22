const express = require('express');
const app = express();
const mysql = require('mysql2/promise');
const PORT = 3000;

// XAMPP MySQL
const dbConfig = {
	host: '37.221.209.228',
	port: 40180,
	user: 'ajax',
	password: 'Password123',
	database: 'ajaxteszt',
};

app.use(express.json());
app.use(express.static('public'));
const pool = mysql.createPool(dbConfig);

// API ENDPOINT-OK
app.post('/api/koszontes', (req, res) =>
{
	const name = req.body.nev;
	if(name)
	{
		res.json
		({
			message: `Hello, ${name}! This AJAX message was sent from the server! :3`
		});
	}
	else
	{
		res.status(400).json
		({
			error: "NAME REQUIRED!!"
		});
	}
})
app.get('/api/szemelyek', async (req, res) =>
{
	let connection;
	try
	{
		connection = await mysql.createConnection(dbConfig);
		const [rows] = await connection.execute('SELECT * FROM Szemelyek ORDER BY id ASC');
		res.json(rows);
	}
	catch (error)
	{
		res.status(500).json({ error: error.message });
	}
	finally
	{
		if (connection)
	{
		await connection.end();
	}
	}
});

app.post('/api/szemelyek', async (req, res) => {
	let connection;
	try
	{
		connection = await mysql.createConnection(dbConfig);
		const { nev, email, telefon, anyja_neve, igazolvany_szam } = req.body;
		const [result] = await connection.execute('INSERT INTO Szemelyek (nev, email, telefon, anyja_neve, igazolvany_szam) VALUES (?, ?, ?, ?, ?)', [nev, email, telefon, anyja_neve, igazolvany_szam]);
		res.json({ success: true, id: result.insertId });
	}
	catch (error)
	{
		res.status(500).json({ error: error.message });
	}
	finally
	{
		if (connection)
		{
			await connection.end();
		}
	}
});

app.put('/api/szemelyek/:id', async (req, res) => {
	let connection;
	try 
	{
		connection = await mysql.createConnection(dbConfig);
		const { nev, email, telefon, anyja_neve, igazolvany_szam } = req.body;
		const id = req.params.id;
		await connection.execute(
			'UPDATE Szemelyek SET nev=?, email=?, telefon=?, anyja_neve=?, igazolvany_szam=? WHERE id=?', [nev, email, telefon, anyja_neve, igazolvany_szam, id]);
		res.json({ success: true });
	}
	catch (error)
	{
		res.status(500).json({ error: error.message });
	}
	finally
	{
		if (connection)
		{
			await connection.end();
		}
	}
});

app.delete('/api/szemelyek/:id', async (req, res) => {
	let connection;
	try
	{
		connection = await mysql.createConnection(dbConfig);
		const id = req.params.id;
		await connection.execute('DELETE FROM Szemelyek WHERE id=?', [id]);
		res.json({ success: true });
	}
	catch (error)
	{
		res.status(500).json({ error: error.message });
	}
	finally
	{
		if (connection)
		{
			await connection.end();
		}
	}
});

app.listen(PORT, () => console.log('http://localhost:3000'));
