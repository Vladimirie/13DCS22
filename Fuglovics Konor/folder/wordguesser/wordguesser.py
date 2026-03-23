# -*- coding: cp1250 -*-
import random
#print("ÁáÉéÍíÓóÖöŐőÚúÜüŰű")

setup = True
on = True
end = True
wordlist = []
selword = []
while setup:
	start = input("Nyelv? / Language? (hun / eng) ")
	if start == "hun":
		with open("magyarszavak.txt", "r", encoding="cp1250") as f:
			wordlist = [line.strip() for line in f]
			setup = False
	elif start == "eng":
		with open("english3.txt", "r") as f:
			wordlist = [line.strip() for line in f]
			setup = False
	else:
		print(f"Nincs olyan nyelv! / No language named {start}!")
		continue
while True:
	#print(word)
	word = wordlist[random.randint(0,len(wordlist))]
	wordinp = input("")
	if len(wordinp) <= len(word):
		while len(wordinp) != len(word):
			wordinp += " "
	if len(wordinp) > len(word):
		print("\nHibás szó")
	correctchars = 0
	incorrectchars = 0
	for i in range(0, len(word)):
		#if i in wordinp:
		if word[i] == wordinp[i]:
			print(word[i], end="")
			correctchars += 1
		else:
			print("_", end="")
			incorrectchars += 1
		#print(f" {correctchars} {incorrectchars}")
	if len(wordinp) > len(word) or len(wordinp) < len(word) or (len(wordinp) == len(word) and incorrectchars > 0):
		print("\nHibás szó")
	print(f"A helyes szó: {word}")
	end = input("Újra? (I/N) ")
	if end == "i":
		continue
	elif end == "n":
		break
#print(f"{len(word)}\n{len(wordinp)}")
