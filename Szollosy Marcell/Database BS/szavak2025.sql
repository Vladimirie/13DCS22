USING szogyak;

DELIMITER $$

CREATE FUNCTION GyakorisagKezelo(p_szoto VARCHAR(100))
RETURN INT
READ SQL DATA
BEGIN
    DECLARE v_gyakori INT;
    SELECT gyakori INTO v_gyakori 
    FROM szavak 
    WHERE szoto = p_szoto 
    LIMIT 1;
    IF v_gyakori IS NOT NULL THEN
        RETURN v_gyakori;
    ELSE 
        RETURN 0;  
    END IF;
END $$

DELIMITER ;

--Feladat 2.

DELIMITER //

CREATE PROCEDURE TopSzavak(IN N INT)
BEGIN 
    SELECT szoto, gyakori FROM szavak ORDER BY gyakorI
    DESC LIMIT N;
END //

DELIMITER ;

--Feladat 3.

DELIMITER **

CREATE FUNCTION SzofajDarab(SzofajKod NVARCHAR(10))
RETURNS INT
AS
BEGIN
    DECLARE SzofajDarab INT;

    SELECT SzofajDarab = COUNT(*)
    FROM Szavak
    WHERE SzofajKod = SzofajKod;

    RETURN SzofajDarab;
END **

DELIMITER ;

-- 4.FELADAT

DELIMITER ++

CREATE PROCEDURE UjSzoKezeles(
    IN p_szoto VARCHAR(100),
    IN p_szofaj VARCHAR(20),
    IN p_gyakori INT
)
BEGIN
    DECLARE v_letezik INT;

    SELECT COUNT(*) INTO v_letezik
    FROM Szavak
    WHERE Szoto = p_szoto;

    IF v_letezik > 0 THEN
        UPDATE Szavak
        SET Gyakori = Gyakori + p_gyakori
        WHERE Szoto = p_szoto;
    ELSE
        INSERT INTO Szavak (Szoto, Szofaj, Gyakori)
        VALUES (p_szoto, p_szofaj, p_gyakori);
    END IF;

END ++

DELIMITER ;