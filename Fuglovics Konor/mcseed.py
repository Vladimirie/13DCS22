import random
import os
import time

print("Minecraft Seed Generator")

on = True
while on:
	number = random.randint(-(2**63), (2**63)-1)
	generate = input("\nPress Enter to generate a seed!")
	if generate == "":
		print(number)
		os.system(f"echo {number}| clip")
		print("\nSeed copied!")
		after = input("")
		while after != "q":
			if after == "help":
				print("All available commands:\nhelp\t displays this\nq\tquits from the console")
				after = input("")
			else:
				print(f"Unknown command: {after}")
				after = input("")
	else:
		print("Ending session...")
		time.sleep(random.uniform(0.001, 3))
		on = False