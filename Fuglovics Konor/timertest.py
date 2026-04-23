from threading import Timer

def callme(foo):
    print(f"{foo}, I have been called")

t = Timer(1, callme, args=["hello"])
t.start()
u = Timer(1, callme, args=["huzzah"])

print("Run code immediately here.")
t.join()
u.start()
print("Run code after Timer ends.")
u.join()