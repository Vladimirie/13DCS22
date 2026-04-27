from tkinter import *
from tkinter.ttk import *
from tkinter import Menu
from tkinter import messagebox
from threading import Timer
import random

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
	hwnd = win32gui.GetParent(root.winfo_id())
	style = win32gui.GetWindowLong(hwnd, win32con.GWL_STYLE)
	style &= ~win32con.WS_MINIMIZEBOX
	win32gui.SetWindowLong(hwnd, win32con.GWL_STYLE, style)
	root.bind('<Map>', None)
#setup.resizable(False, False)
def limit(i):
	if len(i) > 2:
		return False
	try:
		if i != "":
			int(i)
	except ValueError as e:
		messagebox.showerror("Error!", e)
		return False
	return True
style = Style()
style.configure("AskTime.TLabel", anchor="W", padding=(0,4))
Label(setup, text="Add meg az időt a kezdéshez", style="AskTime.TLabel", relief="solid").grid(row=0, column=0, columnspan=3)
min = Entry(setup)
min.config(width=2, validate="key", validatecommand=(setup.register(limit), '%P'))
min.grid(row=1, column=0, sticky="e")
Label(setup, text=":", relief="solid").grid(row=1, column=1)
hr = Entry(setup)
hr.config(width=2, validate="key", validatecommand=(setup.register(limit), '%P'))
hr.grid(row=1, column=2, sticky="w")
accept = Button(setup)
accept.config(text="Indítás!", command("initgame"))
setup.grid_columnconfigure((0,2), weight=1, uniform="column")
setup.bind('<Map>', override)
setup.mainloop()