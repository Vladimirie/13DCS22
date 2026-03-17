# -*- coding: cp1250 -*-
import random
#print("ÁáÉéÍíÓóÖöŐőÚúÜüŰű")

on = True
wordlist = []
selword = []
correctchars = 0
incorrectchars = 0
while True:
	start = input("Nyelv? / Language? (hun / eng)")
	if start == "hun":
		with open("magyarszaval.txt", "r", encoding="cp1250") as f:
			wordlist = [line.strip() for line in f]
	elif start == "eng":
		with open("english3.txt", "r") as f:
			wordlist = [line.strip() for line in f]
	word = wordlist[random.randint(0,len(wordlist))]
	#print(word)
	wordinp = input("")
	for i in word:
		if i in wordinp:
			print(i, end="")
			correctchars += 1
		else:
			print("_", end="")
			incorrectchars += 1
	if len(wordinp) > len(word) or len(wordinp) < len(word) or (len(wordinp) == len(word) and incorrectchars > 0):
		print("\nHibás szó")
	print(f"A helyes szó: {word}")
	end = input("Újra? (I/N) ")
	if end == "i":
		continue
	elif end == "n":
		break
#print(f"{len(word)}\n{len(wordinp)}")
