from tkinter import *
from tkinter.ttk import *
from tkinter import messagebox
import random
import os
import os.path
import win32gui
import win32con
root = Tk()
root.title("File writing test")
ctframe = Frame(root)
ctframe.grid(row=4, column=0, columnspan=2)
w = 220
h = 280
sw = root.winfo_screenwidth()
sh = root.winfo_screenheight()
x = (sw/2)-(w/2)
y = (sh/2)-(h/2)
root.geometry(f"{w}x{h}+{int(x)}+{int(y)-20}")
root.resizable(False,False)
def override(event):
	hwnd = win32gui.GetParent(root.winfo_id())
	style = win32gui.GetWindowLong(hwnd, win32con.GWL_STYLE)
	style &= ~win32con.WS_MINIMIZEBOX
	win32gui.SetWindowLong(hwnd, win32con.GWL_STYLE, style)
	root.bind('<Map>', None)
num = []
chk = BooleanVar()
writemodes = ['r','w','a','r+','w+','a+']
for i in range(101):
	num.append(random.randint(0,100))
char = 0
def charlimit(inp):
	if chk.get() == True:
		char = 260
	else:
		char = 8
	if len(inp) > char:
		return False
	return True
Label(root, text="File name:").grid(row=0, column=0, pady=5, padx=5)
filename = Entry(root, justify="center", width=16, validate="key", validatecommand=(root.register(charlimit),'%P'))
filename.grid(row=0, column=1, pady=(5,0), padx=10)
filesystem = Checkbutton(root, text="Enable modern naming system", variable=chk, onvalue=True, offvalue=False)
filesystem.grid(row=1, column=0, columnspan=2, sticky="w", padx=10, pady=(0,6))
testtxt = StringVar()
Label(root, text="Mode:").grid(row=2, column=0, padx=5, pady=5)
modes = Combobox(root, state="readonly", values=writemodes)
modes.grid(row=2, column=1)
Label(root, text="Contents:").grid(row=3, column=0, padx=5)
scrlx = Scrollbar(ctframe)
scrlx.grid(row=0, column=1, sticky="ns")
text = Text(ctframe, height=8, font="TkTextFont", wrap="none", yscrollcommand=scrlx.set)
text.grid(row=0, column=0)
txtl = len(text.get(1.0,'end-1c'))
print(txtl)
scrlx.config(command=text.yview)
def writerandnums():
	try:
		if os.path.isfile(filename.get()):
			messagebox.showerror("Warning!", "The file already exists!")
		else:
			with open(f"{filename.get()}.txt",modes.get()) as wrnum:
				if modes.get() == writemodes[0]:
					wrnum.read()
				else:
					wrnum.write(', '.join([str(i) for i in num])+"\n")
	except Exception as e:
		messagebox.showerror("An error occured", e)
def writeinput():
	try:
		with open(f"{filename.get()}.txt",modes.get()) as wrtext:
			if modes.get() == writemodes[0]:
				text.delete('1.0', 'end')
				text.insert('end', wrtext.read())
			else:
				wrtext.write(f"{text.get(1.0,'end-1c')}")
				text.delete('1.0', 'end')
	except Exception as e:
		messagebox.showerror("An error occured", e)
def deletefile():
	a = 0
def buttonswitch(*args):
	if writemodes[modes.current()] == "r":
		Button(root, text="Read file", width=20, command=writeinput).grid(row=5, column=0, columnspan=2, pady=6)
	else:
		Button(root, text="Create file", width=20, command=writeinput).grid(row=5, column=0, columnspan=2, pady=6)
modes.bind("<<ComboboxSelected>>", buttonswitch)
root.rowconfigure(5, weight=1)
root.grid_columnconfigure((0,1), weight=1, uniform="column")
ctframe.columnconfigure(0, weight=1)
root.bind('<Map>', override)
root.mainloop()