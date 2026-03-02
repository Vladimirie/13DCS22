from tkinter import *
from tkinter.ttk import *
from tkinter import messagebox
#import keyboard
import win32gui
import win32con
root = Tk()
w = 200
h = 150
sw = root.winfo_screenwidth()
sh = root.winfo_screenheight()
x = (sw/2)-(w/2)
y = (sh/2)-(h/2)
root.resizable(False, False)
root.geometry(f"{w}x{h}+{int(x)}+{int(y)-20}")
def override(event):
	hwnd = win32gui.GetParent(root.winfo_id())
	style = win32gui.GetWindowLong(hwnd, win32con.GWL_STYLE)
	style &= ~win32con.WS_MINIMIZEBOX
	win32gui.SetWindowLong(hwnd, win32con.GWL_STYLE, style)
	root.bind('<Map>', None)
def getkeyboard(event):
	keybrd = (event.keysym, event.keycode)
	keyb.set(keybrd)
	kb.config(textvariable=keyb)
keyb = StringVar()
Label(root, text="Current key pressed", justify="center").grid(row=0, column=0, columnspan=2)
kb = Label(root, text="a")
kb.grid(row=1, column=0, columnspan=2)
root.bind('<Map>', override)
root.bind('<Key>', getkeyboard)
root.mainloop()