<<<<<<< HEAD
from tkinter import *
from tkinter import Menu
from tkinter import messagebox
import random
import time
root = Tk()
root.geometry("350x140")
def ask():
	msgbox = messagebox.askyesno("Warning!", "Are you sure you want to quit?")
	if(msgbox == True):
		root.destroy()
def about():
	aboutdialog = Toplevel(root)
	aboutdialog.geometry("300x250")
	aboutdialog.resizable(False, False)
	aboutdialog.title("About Seed Generator")
	aboutdialog.transient()
	Label(aboutdialog, text="Minecraft Seed Generator Version 0.1").grid(row=0, column=0, sticky="ew")
	Label(aboutdialog, text="Created by Sound Crafter").grid(row=1, column=0)
	Button(aboutdialog, text="Close", width=10, command=aboutdialog.destroy).grid(row=2, column=0)
	aboutdialog.columnconfigure(0, weight=1)
	aboutdialog.rowconfigure(2, weight=1)
	aboutdialog.mainloop()
def onclick():
	rnd = random.randint(-(2**63), (2**63)-1)
	rng.set(rnd)
	seednum = rnd
	lbl.config(textvariable=rng)
def copyclip():
	root.clipboard_clear()
	root.clipboard_append(f"{rng.get()}")
	root.update()
	copy.config(text="Seed copied!", fg='#0f0')
menubar = Menu(root)
root.config(menu=menubar)
about_menu = Menu(menubar, tearoff=False)
about_menu.add_command(label="About Seed Generator", command=about)
menubar.add_cascade(label="Help", menu=about_menu)
root.resizable(False, False)
rng = IntVar()
root.title("Minecraft Seed Generator")
copy = Label(root)
copy.config(pady=10, text="Generate a seed.")
copy.grid(row=1, column=0, columnspan=2, sticky="ew")
lbl = Label(root)
lbl.config(relief="sunken")
lbl.grid(row=2, column=0, columnspan=2, sticky="ew", padx=50)
Button(root, text="Generate", command=onclick, width=10).grid(row=3, column=0, sticky="ew", padx=50, pady=10)
Button(root, text="Copy", command=copyclip, width=10).grid(row=3, column=1, sticky="ew", padx=50, pady=10)
root.columnconfigure(0, weight=1)
root.columnconfigure(1, weight=1)
root.protocol("WM_DELETE_WINDOW", ask)
=======
from tkinter import *
from tkinter import Menu
from tkinter import messagebox
import random
import time
root = Tk()
root.geometry("350x140")
def ask():
	msgbox = messagebox.askyesno("Warning!", "Are you sure you want to quit?")
	if(msgbox == True):
		root.destroy()
def about():
	aboutdialog = Toplevel(root)
	aboutdialog.geometry("300x250")
	aboutdialog.resizable(False, False)
	aboutdialog.title("About Seed Generator")
	aboutdialog.transient()
	Label(aboutdialog, text="Minecraft Seed Generator Version 0.1").grid(row=0, column=0, sticky="ew")
	Label(aboutdialog, text="Created by Sound Crafter").grid(row=1, column=0)
	Button(aboutdialog, text="Close", width=10, command=aboutdialog.destroy).grid(row=2, column=0)
	aboutdialog.columnconfigure(0, weight=1)
	aboutdialog.rowconfigure(2, weight=1)
	aboutdialog.mainloop()
def onclick():
	rnd = random.randint(-(2**63), (2**63)-1)
	rng.set(rnd)
	seednum = rnd
	lbl.config(textvariable=rng)
def copyclip():
	root.clipboard_clear()
	root.clipboard_append(f"{rng.get()}")
	root.update()
	copy.config(text="Seed copied!", fg='#0f0')
menubar = Menu(root)
root.config(menu=menubar)
about_menu = Menu(menubar, tearoff=False)
about_menu.add_command(label="About Seed Generator", command=about)
menubar.add_cascade(label="Help", menu=about_menu)
root.resizable(False, False)
rng = IntVar()
root.title("Minecraft Seed Generator")
copy = Label(root)
copy.config(pady=10, text="Generate a seed.")
copy.grid(row=1, column=0, columnspan=2, sticky="ew")
lbl = Label(root)
lbl.config(relief="sunken")
lbl.grid(row=2, column=0, columnspan=2, sticky="ew", padx=50)
Button(root, text="Generate", command=onclick, width=10).grid(row=3, column=0, sticky="ew", padx=50, pady=10)
Button(root, text="Copy", command=copyclip, width=10).grid(row=3, column=1, sticky="ew", padx=50, pady=10)
root.columnconfigure(0, weight=1)
root.columnconfigure(1, weight=1)
root.protocol("WM_DELETE_WINDOW", ask)
>>>>>>> 508682966dc1c50aeb4017a64c1f9d921eaa4e6d
root.mainloop()