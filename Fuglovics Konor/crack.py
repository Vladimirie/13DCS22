from tkinter import *
from tkinter.ttk import *
from tkinter import Menu
from tkinter import messagebox
from threading import Timer
import random
import win32gui
import win32con

setupdone = False
while not setupdone:
	setup = Tk()
	stw = 250
	sth = 100
	sw = setup.winfo_screenwidth()
	sh = setup.winfo_screenheight()
	stx = (sw/2)-(stw/2)
	sty = (sh/2)-(sth/2)
	setup.geometry(f"{stw}x{sth}+{int(stx)}+{int(sty)-20}")
	setup.title("Inicializálás")
	def override(event):
		hwnd = win32gui.GetParent(setup.winfo_id())
		style = win32gui.GetWindowLong(hwnd, win32con.GWL_STYLE)
		style &= ~win32con.WS_MINIMIZEBOX
		style &= ~win32con.WS_MAXIMIZEBOX
		win32gui.SetWindowLong(hwnd, win32con.GWL_STYLE, style)
		setup.bind('<Map>', None)
	#setup.resizable(False, False)
	def ask():
		msgbox = messagebox.askyesno("Warning!", "Are you sure you want to quit?")
		if msgbox == True:
			setup.destroy()
	def close():
		mn = min.get()
		ho = hr.get()
		try:
			m = int(mn)
			h = int(ho)
			if m == 1:
				messagebox.showerror("Error!", "a")
		except ValueError:
			messagebox.showerror("!!!", "!")
		#setup.destroy()
	def limit(i):
		if len(i) > 2:
			return False
		if i.isspace() or i.isalpha():
			#print("working")
			messagebox.showerror("Error!", "Not a number!")
			return False
		return True
	style = Style()
	style.configure("AskTime.TLabel", anchor="W", padding=(0,4))
	Label(setup, text="Add meg az időt a kezdéshez", style="AskTime.TLabel").grid(row=0, column=0, columnspan=3)
	min = Entry(setup)
	min.config(width=2, validate="key", validatecommand=(setup.register(limit), '%P'))
	min.grid(row=1, column=0, sticky="e")
	Label(setup, text=":").grid(row=1, column=1, sticky="ew")
	hr = Entry(setup)
	hr.config(width=2, validate="key", validatecommand=(setup.register(limit), '%P'))
	hr.grid(row=1, column=2, sticky="w")
	Button(setup, text="Indítás!", width=20, command=close).grid(row=2, column=0, columnspan=3)
	setup.grid_columnconfigure((0,2), weight=1, uniform="column")
	setup.bind('<Map>', override)
	setup.protocol("WM_DELETE_WINDOW", ask)
	setup.mainloop()
'''def safe_conversion():
	user_input = entry.get()
	try:
		number = int(user_input)
		print(f"Valid integer: {number}")
		if number == 10:
			return number
		else:
			messagebox.showerror("!!!", "!")
	except ValueError:
		print("Invalid input - not an integer")
		return None

root = Tk()
entry = Entry(root)
entry.grid()

Button(root, text="Convert", command=safe_conversion).grid()
root.mainloop()'''
	