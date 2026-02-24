-- Active: 1771314925803@@127.0.0.1@3306@szogyak

DELIMITER $$

CREATE FUNCTION GyakorisagKezelo(p_szoto VARCHAR(100))
RETURNS INT
READS SQL DATA
BEGIN
    DECLARE v_gyakori INT;
    SELECT gyakori INTO v_gyakori FROM szo10000 WHERE szoto = p_szoto LIMIT 1;
    IF v_gyakori IS NULL THEN 
        RETURN 0;
    ELSE
        RETURN v_gyakori;
    END IF;
END $$

DELIMITER ;

DELIMITER //

CREATE PROCEDURE TopSzavak(IN N INT)
BEGIN
    SELECT szoto, gyakori FROM szo10000 ORDER BY gyakori DESC LIMIT N;
END //

DELIMITER ;

DELIMITER ßß

CREATE FUNCTION SzofajDarab(p_szofajkod VARCHAR(100))
RETURNS INT
READS SQL DATA
BEGIN
    DECLARE v_darab INT;
    SELECT COUNT(szofaj) INTO v_darab FROM szo10000 WHERE szofaj = p_szofajkod;
    RetURN v_darab;
END ßß

DELIMITER ;

DELIMITER ŁŁ

CREATE PROCEDURE UjSzoKezeles(IN p_szoto VARCHAR(100), IN p_szofaj VARCHAR(100), IN p_gyakori INT)
BEGIN
    IF EXISTS(SELECT szoto from szo10000 WHERE p_szoto = szoto) THEN
        UPDATE szo10000 SET gyakori = gyakori + p_gyakori WHERE szoto = p_szoto;
    ELSE
        INSERT INTO szo10000 (szoto, szofaj, gyakori) VALUES(p_szoto,p_szofaj,p_gyakori);
    END IF;
END ŁŁ

DELIMITER ;

DELIMITER MagyarHimnusz

CREATE TRIGGER FontosSzo
BEFORE DELETE ON szo10000
FOR EACH ROW
BEGIN
    IF OLD.gyakori >= 100000 THEN
        SIGNAL SQLSTATE "45000" SET MESSAGE_TEXT = "Hiba: Nem törölhet 100 000-nél nagyobb gyakoriságú szót.";
    END IF;
END MagyarHimnusz
DELIMITER ;

DELIMITER MagyarHimnusz

CREATE PROCEDURE SzofajStatisztika(IN p_szofaj VARCHAR(100), OUT k_atlagGyak DECIMAL, OUT k_legritkabb INT)
BEGIN
	SELECT AVG(gyakori) INTO k_atlagGyak FROM szo10000 WHERE szofaj = p_szofaj;
    SELECT gyakori INTO k_legritkabb FROM szo10000 WHERE szofaj = p_szofaj ORDER BY gyakori DESC LIMIT 1;
END MagyarHimnusz
DELIMITER ;