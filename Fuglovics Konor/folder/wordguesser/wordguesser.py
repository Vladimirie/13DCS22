# -*- coding: cp1250 -*-
import random
#print("ÁáÉéÍíÓóÖöŐőÚúÜüŰű")

setup = True
end = True
tries = 5
wordlist = []
selword = []
chars = []
currentword = ""
while setup:
	start = input("Nyelv? / Language? (hun / eng) ")
	if start == "hun":
		with open("magyarszavak.txt", "r", encoding="cp1250") as f:
			wordlist = [line.strip() for line in f]
			word = wordlist[random.randint(0,len(wordlist))]
			setup = False
	elif start == "eng":
		with open("english3.txt", "r") as f:
			wordlist = [line.strip() for line in f]
			word = wordlist[random.randint(0,len(wordlist))]
			setup = False
	else:
		print(f"Nincs olyan nyelv! / No language named {start}!")
		continue
while tries != 0:
	#print(word)
	wordinp = input("? ")
	if len(wordinp) <= len(word):
		while len(wordinp) != len(word):
			wordinp += " "
	correctchars = 0
	incorrectchars = 0
	for i in range(0, len(word)):
		#if i in wordinp:
		if word[i] == wordinp[i]:
			#print(word[i], end="")
			chars.append(word[i])
			print(chars)
			correctchars += 1
		else:
			#print("_", end="")
			chars.append("_")
			print(chars)
			incorrectchars += 1
	for j in range(0, len(chars)):
		print(chars[j], end="")
		currentword += chars[j]
		print(''.join(chars[j]))
		#print(f" {correctchars} {incorrectchars}")
	if len(wordinp) > len(word) or len(wordinp) < len(word) or (len(wordinp) == len(word) and incorrectchars > 0):
		print("\nHibás szó")
		tries -= 1
	print(f"A helyes szó: {word}")
while end:
	ask = input("Újra? (I/N) ")
	if ask == "i":
		continue
	elif ask == "n":
		break
#print(f"{len(word)}\n{len(wordinp)}")
