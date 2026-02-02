from threading import Timer

def callme(foo):
    print(f"{foo}, I have been called")

t = Timer(1, callme, args=["hello"])
t.start()

print("Run code immediately here.")
t.join()
print("Run code after Timer ends.")