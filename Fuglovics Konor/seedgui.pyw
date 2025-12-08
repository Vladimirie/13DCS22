from tkinter import *
from tkinter.ttk import *
from tkinter import Menu
from tkinter import messagebox
from threading import Timer
import random
import time
root = Tk()
w = 350
h = 140
sw = root.winfo_screenwidth()
sh = root.winfo_screenheight()
x = (sw/2)-(w/2)
y = (sh/2)-(h/2)
print(f"{x}\n{y}")
root.geometry(f"{w}x{h}+{int(x)}+{int(y)-20}")
def ask():
    msgbox = messagebox.askyesno("Warning!", "Are you sure you want to quit?")
    if msgbox == True:
        root.destroy()
def about():
    aboutdialog = Toplevel(root)
    aw = 300
    ah = 250
    ax = (sw/2)-(aw/2)
    ay = (sh/2)-(ah/2)
    aboutdialog.geometry(f"{aw}x{ah}+{int(ax)}+{int(ay)-20}")
    aboutdialog.resizable(False, False)
    aboutdialog.title("About Seed Generator")
    aboutdialog.transient()
    Label(aboutdialog, text="Minecraft Seed Generator Version 0.1").grid(row=0, column=0)
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
    def change():
            copy.config(text="Generate a seed.", style="Copy.TLabel")
    t = Timer(1.0,change)
    root.clipboard_clear()
    root.clipboard_append(f"{rng.get()}")
    root.update()
    copy.config(text="Seed copied!", style="SeedCopied.TLabel")
    t.start()
style = Style()
style.configure("Copy.TLabel", sticky="ew", padding=(0,10))
style.configure("SeedCopied.TLabel", sticky="ew", padding=(0,10), foreground='#0a0')
style.configure("Error.TLabel", sticky="ew", padding=(0,10), foreground='#f00')
style.configure("Lbl.TLabel", sticky="ew", width=40)
menubar = Menu(root)
root.config(menu=menubar)
about_menu = Menu(menubar, tearoff=False)
about_menu.add_command(label="About Seed Generator", command=about)
menubar.add_cascade(label="Help", menu=about_menu)
root.resizable(False, False)
rng = IntVar()
root.title("Minecraft Seed Generator")
copy = Label(root)
copy.config(text="Generate a seed.", style="Copy.TLabel")
print(style.lookup('Copy.TLabel','foreground'))
copy.grid(row=1, column=0, columnspan=2)
lbl = Label(root)
lbl.config(relief="sunken", style="Lbl.TLabel", anchor="center")
lbl.grid(row=2, column=0, columnspan=2)
Button(root, text="Generate", command=onclick, width=10).grid(row=3, column=0, sticky="ew", padx=50, pady=10)
Button(root, text="Copy", command=copyclip, width=10).grid(row=3, column=1, sticky="ew", padx=50, pady=10)
root.columnconfigure(0, weight=1)
root.columnconfigure(1, weight=1)
root.protocol("WM_DELETE_WINDOW", ask)
root.mainloop()
