SELECT nev FROM csapat WHERE nev LIKE "#%"

SELECT nevado FROM feladatsor WHERE nevado LIKE "% %"
AND nevado NOT LIKE "% % %"

SELECT nevado, kituzes, hatarido FROM feladatsor WHERE kituzes < DATE("2018-12-31") AND hatarido > DATE("2018-12-31")

SELECT nev, pontszam FROM csapat, megoldas WHERE csapat.id = csapatid
GROUP BY nev ORDER BY pontszam DESC

SELECT nevado, ag, SUM(pontszam) FROM feladatsor, feladat
WHERE feladatsorid = feladatsor.id
GROUP BY nevado HAVING SUM(pontszam) < 150;

SELECT DISTINCT nev FROM megoldas, csapat, feladat
WHERE feladatid = feladat.id
AND csapatid = csapat.id
AND feladat.pontszam = megoldas.pontszam

SELECT nevado, COUNT(*) FROM feladatsor, feladat, megoldas, csapat
WHERE nev = "#win"
AND feladatsorid = feladatsor.id
AND feladat.id = megoldas.feladatid
AND csapatid = csapat.id
AND megoldas.pontszam = 0

SELECT nevado, ABS(DATEDIFF(kituzes, hatarido)) as diff FROM feladatsor
ORDER BY diff ASC

