<<<<<<< HEAD
-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: dbp.omega:3306
-- Generation Time: Nov 03, 2025 at 12:18 PM
-- Server version: 10.11.14-MariaDB-0+deb12u2
-- PHP Version: 7.2.34-55+0~20250707.109+debian12~1.gbp140deb

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ajaxteszt`
--
CREATE DATABASE IF NOT EXISTS `ajaxteszt` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `ajaxteszt`;

-- --------------------------------------------------------

--
-- Table structure for table `Ajax_Teszt`
--

CREATE TABLE `Ajax_Teszt` (
  `id` int(11) NOT NULL,
  `nev` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `telefon` varchar(20) DEFAULT NULL,
  `anyja_neve` varchar(100) DEFAULT NULL,
  `igazolvany_szam` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Ajax_Teszt`
--

INSERT INTO `Ajax_Teszt` (`id`, `nev`, `email`, `telefon`, `anyja_neve`, `igazolvany_szam`) VALUES
(1, 'Kovács Béla', 'be@kovacs.hu', '06123456789', 'Nagy Erzsébet', 'AB123456'),
(2, 'Németh Anna', 'anna.nemeth@example.com', '06987654321', 'Kiss Mária', 'CD654321'),
(3, 'Szabó Gábor', 'gabor.szabo@example.hu', '06701234567', 'Molnár Ilona', 'EF112233'),
(4, 'Tóth Éva', 'eva.toth@mail.com', '06301239876', 'Farkas Judit', 'GH445566'),
(5, 'Varga László', 'laszlo.varga@example.com', '06207654321', 'Bíró Katalin', 'IJ778899'),
(6, 'Horváth Rita', 'rita.horvath@domain.hu', '06119876543', 'Balogh Andrea', 'KL334455'),
(7, 'Farkas Péter', 'peter.farkas@webmail.hu', '06789876543', 'Tóth Zsuzsanna', 'MN667788'),
(8, 'Papp Katalin', 'katalin.papp@gmail.com', '06905678901', 'Nagy Judit', 'OP990011'),
(9, 'Kiss Tamás', 'tamas.kiss@example.hu', '06204567890', 'Siklós Anna', 'QR223344'),
(10, 'Balogh Gergely', 'gergely.balogh@mail.hu', '06305678901', 'Szűcs Erika', 'ST556677');

-- --------------------------------------------------------

--
-- Table structure for table `Feladatok`
--

CREATE TABLE `Feladatok` (
  `id` int(11) NOT NULL,
  `title` varchar(255) NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Feladatok`
--

INSERT INTO `Feladatok` (`id`, `title`, `description`) VALUES
(4, 'Feladat 4', 'További feladat leírás.'),
(5, 'Feladat 5', 'Minta feladat 5.'),
(6, 'Feladat 6', 'Hatodik példa feladat.'),
(7, 'Feladat 7', 'Hetedik feladat itt.'),
(8, 'Feladat 8', 'Nyolcadik leírás.'),
(11, 'Feladat 10', 'Tizedik feladat'),
(14, 'Faladatx', 'wtwtw');

-- --------------------------------------------------------

--
-- Table structure for table `Szemelyek`
--

CREATE TABLE `Szemelyek` (
  `id` int(11) NOT NULL,
  `nev` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `telefon` varchar(20) DEFAULT NULL,
  `anyja_neve` varchar(100) DEFAULT NULL,
  `igazolvany_szam` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Szemelyek`
--

INSERT INTO `Szemelyek` (`id`, `nev`, `email`, `telefon`, `anyja_neve`, `igazolvany_szam`) VALUES
(1, 'Kovács Béla', 'be@kovacs.hu', '06123456789', 'Nagy Erzsébet', 'AB123456'),
(2, 'Németh Anna', 'anna.nemeth@example.com', '06987654321', 'Kiss Mária', 'CD654321'),
(3, 'Szabó Gábor', 'gabor.szabo@example.hu', '06701234567', 'Molnár Ilona', 'EF112233'),
(4, 'Tóth Éva', 'eva.toth@mail.com', '06301239876', 'Farkas Judit', 'GH445566'),
(5, 'Varga László', 'laszlo.varga@example.com', '06207654321', 'Bíró Katalin', 'IJ778899'),
(6, 'Horváth Rita', 'rita.horvath@domain.hu', '06119876543', 'Balogh Andrea', 'KL334455'),
(7, 'Farkas Péter', 'peter.farkas@webmail.hu', '06789876543', 'Tóth Zsuzsanna', 'MN667788'),
(8, 'Papp Katalin', 'katalin.papp@gmail.com', '06905678901', 'Nagy Judit', 'OP990011'),
(9, 'Kiss Tamás', 'tamas.kiss@example.hu', '06204567890', 'Siklós Anna', 'QR223344'),
(10, 'Balogh Gergely', 'gergely.balogh@mail.hu', '06305678901', 'Szűcs Erika', 'ST556677');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Ajax_Teszt`
--
ALTER TABLE `Ajax_Teszt`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `Feladatok`
--
ALTER TABLE `Feladatok`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `Szemelyek`
--
ALTER TABLE `Szemelyek`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Ajax_Teszt`
--
ALTER TABLE `Ajax_Teszt`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `Feladatok`
--
ALTER TABLE `Feladatok`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `Szemelyek`
--
ALTER TABLE `Szemelyek`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
=======
-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: dbp.omega:3306
-- Generation Time: Nov 03, 2025 at 12:18 PM
-- Server version: 10.11.14-MariaDB-0+deb12u2
-- PHP Version: 7.2.34-55+0~20250707.109+debian12~1.gbp140deb

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ajaxteszt`
--
CREATE DATABASE IF NOT EXISTS `ajaxteszt` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `ajaxteszt`;

-- --------------------------------------------------------

--
-- Table structure for table `Ajax_Teszt`
--

CREATE TABLE `Ajax_Teszt` (
  `id` int(11) NOT NULL,
  `nev` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `telefon` varchar(20) DEFAULT NULL,
  `anyja_neve` varchar(100) DEFAULT NULL,
  `igazolvany_szam` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Ajax_Teszt`
--

INSERT INTO `Ajax_Teszt` (`id`, `nev`, `email`, `telefon`, `anyja_neve`, `igazolvany_szam`) VALUES
(1, 'Kovács Béla', 'be@kovacs.hu', '06123456789', 'Nagy Erzsébet', 'AB123456'),
(2, 'Németh Anna', 'anna.nemeth@example.com', '06987654321', 'Kiss Mária', 'CD654321'),
(3, 'Szabó Gábor', 'gabor.szabo@example.hu', '06701234567', 'Molnár Ilona', 'EF112233'),
(4, 'Tóth Éva', 'eva.toth@mail.com', '06301239876', 'Farkas Judit', 'GH445566'),
(5, 'Varga László', 'laszlo.varga@example.com', '06207654321', 'Bíró Katalin', 'IJ778899'),
(6, 'Horváth Rita', 'rita.horvath@domain.hu', '06119876543', 'Balogh Andrea', 'KL334455'),
(7, 'Farkas Péter', 'peter.farkas@webmail.hu', '06789876543', 'Tóth Zsuzsanna', 'MN667788'),
(8, 'Papp Katalin', 'katalin.papp@gmail.com', '06905678901', 'Nagy Judit', 'OP990011'),
(9, 'Kiss Tamás', 'tamas.kiss@example.hu', '06204567890', 'Siklós Anna', 'QR223344'),
(10, 'Balogh Gergely', 'gergely.balogh@mail.hu', '06305678901', 'Szűcs Erika', 'ST556677');

-- --------------------------------------------------------

--
-- Table structure for table `Feladatok`
--

CREATE TABLE `Feladatok` (
  `id` int(11) NOT NULL,
  `title` varchar(255) NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Feladatok`
--

INSERT INTO `Feladatok` (`id`, `title`, `description`) VALUES
(4, 'Feladat 4', 'További feladat leírás.'),
(5, 'Feladat 5', 'Minta feladat 5.'),
(6, 'Feladat 6', 'Hatodik példa feladat.'),
(7, 'Feladat 7', 'Hetedik feladat itt.'),
(8, 'Feladat 8', 'Nyolcadik leírás.'),
(11, 'Feladat 10', 'Tizedik feladat'),
(14, 'Faladatx', 'wtwtw');

-- --------------------------------------------------------

--
-- Table structure for table `Szemelyek`
--

CREATE TABLE `Szemelyek` (
  `id` int(11) NOT NULL,
  `nev` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `telefon` varchar(20) DEFAULT NULL,
  `anyja_neve` varchar(100) DEFAULT NULL,
  `igazolvany_szam` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Szemelyek`
--

INSERT INTO `Szemelyek` (`id`, `nev`, `email`, `telefon`, `anyja_neve`, `igazolvany_szam`) VALUES
(1, 'Kovács Béla', 'be@kovacs.hu', '06123456789', 'Nagy Erzsébet', 'AB123456'),
(2, 'Németh Anna', 'anna.nemeth@example.com', '06987654321', 'Kiss Mária', 'CD654321'),
(3, 'Szabó Gábor', 'gabor.szabo@example.hu', '06701234567', 'Molnár Ilona', 'EF112233'),
(4, 'Tóth Éva', 'eva.toth@mail.com', '06301239876', 'Farkas Judit', 'GH445566'),
(5, 'Varga László', 'laszlo.varga@example.com', '06207654321', 'Bíró Katalin', 'IJ778899'),
(6, 'Horváth Rita', 'rita.horvath@domain.hu', '06119876543', 'Balogh Andrea', 'KL334455'),
(7, 'Farkas Péter', 'peter.farkas@webmail.hu', '06789876543', 'Tóth Zsuzsanna', 'MN667788'),
(8, 'Papp Katalin', 'katalin.papp@gmail.com', '06905678901', 'Nagy Judit', 'OP990011'),
(9, 'Kiss Tamás', 'tamas.kiss@example.hu', '06204567890', 'Siklós Anna', 'QR223344'),
(10, 'Balogh Gergely', 'gergely.balogh@mail.hu', '06305678901', 'Szűcs Erika', 'ST556677');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Ajax_Teszt`
--
ALTER TABLE `Ajax_Teszt`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `Feladatok`
--
ALTER TABLE `Feladatok`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `Szemelyek`
--
ALTER TABLE `Szemelyek`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Ajax_Teszt`
--
ALTER TABLE `Ajax_Teszt`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `Feladatok`
--
ALTER TABLE `Feladatok`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `Szemelyek`
--
ALTER TABLE `Szemelyek`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
>>>>>>> 508682966dc1c50aeb4017a64c1f9d921eaa4e6d
