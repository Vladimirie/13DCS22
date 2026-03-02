const email = document.getElementById("email");
const pswrd = document.getElementById("password");
const error = document.getElementById("error");
const btn = document.getElementById("submit"); 
btn.addEventListener("click", SubmitLogin);

function CheckEmailFormat()
{
	let emailstring = email.value;
	let mails = ["gmail","freemail","yahoo","outlook"]
	if(emailstring.length == 0)
	{
		error.innerHTML = "E-mail nem lehet üres!";
		error.style.color = "red";
	}
	else if (emailstring.length > 0)
	{
		let failcheckmail = false;
		for (let i=0;i<mails.length;i++)
		{
			if(!emailstring.includes(mails[i])&&!emailstring.includes("@")&&!emailstring.includes(".com"))
			{
				failcheckmail = true;
			}
		}
		if(failcheckmail)
		{
			error.innerHTML = "Nem érvényes e-mail.";
			error.style.color = "red";
		}
		else
		{
			error.innerHTML = "";
		}
	}
	else
	{
		error.innerHTML = "";
	}
}
function CheckPassChars(pswrd)
{
	let chars = "!@#$%^&*()-_=+[{]};:'\",<.>/?\\|";
	for (let i=0;i>chars.length;i++)
	{
		if(!pswrd.includes(chars[i]))
		{
			return false;
		}
		else
		{
			return true;
		}
	}
}
function CheckPassword()
{
	let pass = pswrd.value.length;
	if (pass == 0)
	{
		error.innerHTML = "Üres jelszó!";
		error.style.color = "red";
	}
	else if(pass > 4 && pass < 10)
	{
		error.innerHTML = "Jelszó túl rövid!";
		error.style.color = "red";
	}
	else if (!CheckPassChars())
	{
		error.innerHTML = "Jelszó túl egyszerű!";
		error.style.color = "red";
	}
function SubmitLogin()
{
	CheckEmailFormat();
	CheckPassword();
}
