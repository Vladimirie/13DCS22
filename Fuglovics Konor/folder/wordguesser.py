import random
import codecs
'''def hunencode(letter):
	letter.encode("utf-8")
	encoded = letter.decode("utf-8")
	return encoded'''

wordlist = []
with open("magyarszaval.txt", "r", encoding="cp1250") as f:
	wordlist = [line.strip() for line in f]
word = wordlist[random.randint(0,len(wordlist))]
wordinp = input("")