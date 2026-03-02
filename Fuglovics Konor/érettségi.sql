SELECT diaknev FROM vizsgazo WHERE evfolyam = "12"
AND osztaly = "D"

SELECT osztaly, evfolyam, COUNT(diaknev) FROM vizsgazo
WHERE evfolyam = 12 GROUP BY osztaly

SELECT DISTINCT nev FROM tanar, vizsgak WHERE tanarid = tanar.id AND vizsgatargy = "angol nyelv"

SELECT COUNT(vizsgatargy), diaknev, evfolyam, osztaly
FROM vizsgazo, vizsgak WHERE vizsgazoid = vizsgazo.id
GROUP BY diaknev, evfolyam, osztaly
HAVING COUNT(vizsgatargy) > 3