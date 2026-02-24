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
END ßß

DELIMITER ;