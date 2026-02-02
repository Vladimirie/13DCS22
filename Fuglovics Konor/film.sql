SELECT cim, mufaj, hossz FROM filmek WHERE hossz <= 45 ORDER BY hossz ASC

SELECT cim AS cím, nev AS rendező, ev AS "készítés éve", CONCAT("http://videotorium.hu/hu/recordings/", filmazon) AS videóhiv
FROM alkotok, filmek, filmstab WHERE alkotoazon = alkazon AND filmazon = fazon AND munkakor = 1

SELECT cim AS "cím", nev AS "rendező", munkakor, elhunyt
FROM alkotok, filmek, filmstab WHERE alkotoazon = alkazon
AND filmazon = fazon AND munkakor IN(1,6) AND elhunyt = ""
AND cim = "Mephisto"