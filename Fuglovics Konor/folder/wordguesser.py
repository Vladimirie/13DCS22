import random
import sys
print(sys.getdefaultencoding())
a = "ő".encode("utf-8").decode("unicode-escape")
b = a
print(a.encode("utf-8"))


"""def hunencode(letter):
	letter.encode("utf-8")
	encoded = letter.decode("utf-8")
	return encoded
	
wordlist = []
with open("magyar-szavak.txt", "r") as f:
	wordlist = [line.strip() for line in f]
for word in wordlist:
	word.encode("utf-8")
	hunencode(word)
"""