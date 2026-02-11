const express = require('express'); 
const mysql = require('mysql2/promise'); 
const app = express(); 
 
const db_config = { 
  host: "37.221.209.228", 
  port: 40180, 
  user: "ajax", 
  password: "Password123", 
  database: "CarMaintance" 
}; 
 
app.use(express.json()); 
app.use(express.static('public')); 
 
app.get('/', (req, res) => { 
  res.sendFile(__dirname + '/public/index.html'); 
}); 
 
const PORT = 3000; 
app.listen(PORT, () => { 
  console.log("========================================"); 
  console.log("Szerver sikeresen elindult!"); 
  console.log("Elerheto: http://localhost:" + PORT); 
  console.log("Leallitashoz: Ctrl+C"); 
  console.log("========================================"); 
}); 

app.get('/api/cars', async (req, res) =>
{
	let connection;
	try
	{
		connection = await mysql.createConnection(db_config);
		const [rows] = await connection.execute('SELECT * FROM Cars');
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
/*app.post('/api/cars', async (req, res) => {
	let connection;
	try
	{
		connection = await mysql.createConnection(db_config);
		const { fullname, email, phone, mothername, birthdate, address } = req.body;
		const [result] = await connection.execute('INSERT INTO Owners (FullName, Email, Phone, MotherName, BirthDate, Address) VALUES (?, ?, ?, ?, ?, ?)', [fullname, email, phone, mothername, birthdate, address]);
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
});*/
app.post('/api/cars/:id', async (req, res) => {
	let connection;
	try 
	{
		connection = await mysql.createConnection(db_config);
		const { licenseplate, brand, model } = req.body;
		const id = req.params.carid;
		await connection.execute(
			'UPDATE Cars SET LicensePlate=?, Brand=?, Model=? WHERE CarID=?', [licenseplate, brand, model, id]);
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
/*app.delete('/api/szemelyek/:id', async (req, res) => {
	let connection;
	try
	{
		connection = await mysql.createConnection(db_config);
		const id = req.params.id;
		await connection.execute('DELETE FROM Szemelyek WHERE OwnerID=?', [id]);
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
});*/