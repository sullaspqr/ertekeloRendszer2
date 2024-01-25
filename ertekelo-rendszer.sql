-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Jan 25. 09:49
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `ertekelo-rendszer`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ertekelesek`
--

CREATE TABLE `ertekelesek` (
  `id` int(11) NOT NULL,
  `screening_id` int(11) NOT NULL,
  `szempont_id` int(11) NOT NULL,
  `pontertek` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `ertekelesek`
--

INSERT INTO `ertekelesek` (`id`, `screening_id`, `szempont_id`, `pontertek`) VALUES
(1, 1, 0, 6),
(2, 2, 0, 4),
(3, 1, 1, 5),
(4, 2, 1, 4),
(5, 1, 2, 6),
(6, 2, 2, 5),
(7, 1, 3, 5),
(8, 2, 3, 4),
(9, 1, 4, 6),
(10, 2, 4, 5),
(11, 1, 5, 6),
(12, 2, 5, 4),
(13, 1, 6, 6),
(14, 2, 6, 5),
(15, 1, 7, 6);

-- --------------------------------------------------------

--
-- A nézet helyettes szerkezete `getter`
-- (Lásd alább az aktuális nézetet)
--
CREATE TABLE `getter` (
`nev` varchar(255)
,`pontertek` int(11)
,`szorzo` int(11)
,`szempont-nev` varchar(255)
,`végső pont` bigint(21)
);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `screening`
--

CREATE TABLE `screening` (
  `id` int(11) NOT NULL,
  `nev` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `screening`
--

INSERT INTO `screening` (`id`, `nev`) VALUES
(1, 'Példa Tanár1'),
(2, 'Dr. Random Arc'),
(3, 'Mr.X');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szempont`
--

CREATE TABLE `szempont` (
  `id` int(11) NOT NULL,
  `szempont-nev` varchar(255) NOT NULL,
  `szorzo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `szempont`
--

INSERT INTO `szempont` (`id`, `szempont-nev`, `szorzo`) VALUES
(0, 'képzettség-szakképzettség', 3),
(1, 'szakmai-tapasztalat', 4),
(2, 'munkaerőpiaci-érték', 8),
(3, 'szakmai felkészültség', 11),
(4, 'szakképzésreveláns korszerű módszertan alkalmazása', 18),
(5, 'pedagógiai tervezés', 9),
(6, 'pedagógiai értékelés', 10),
(7, 'együttműködés más oktatókkal, szülőkkel, stb.', 7),
(8, 'személyiségfejlesztő, csoporttámogató tevékenység', 12),
(9, 'innovációs tevékenység', 18);

-- --------------------------------------------------------

--
-- A nézet helyettes szerkezete `végsőpont2`
-- (Lásd alább az aktuális nézetet)
--
CREATE TABLE `végsőpont2` (
`nev` varchar(255)
,`végső pont` decimal(42,0)
);

-- --------------------------------------------------------

--
-- Nézet szerkezete `getter`
--
DROP TABLE IF EXISTS `getter`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `getter`  AS SELECT `screening`.`nev` AS `nev`, `ertekelesek`.`pontertek` AS `pontertek`, `szempont`.`szorzo` AS `szorzo`, `szempont`.`szempont-nev` AS `szempont-nev`, `ertekelesek`.`pontertek`* `szempont`.`szorzo` AS `végső pont` FROM ((`screening` join `ertekelesek` on(`screening`.`id` = `ertekelesek`.`screening_id`)) join `szempont` on(`szempont`.`id` = `ertekelesek`.`szempont_id`)) ;

-- --------------------------------------------------------

--
-- Nézet szerkezete `végsőpont2`
--
DROP TABLE IF EXISTS `végsőpont2`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `végsőpont2`  AS SELECT `screening`.`nev` AS `nev`, sum(`ertekelesek`.`pontertek` * `szempont`.`szorzo`) AS `végső pont` FROM ((`screening` join `ertekelesek` on(`screening`.`id` = `ertekelesek`.`screening_id`)) join `szempont` on(`szempont`.`id` = `ertekelesek`.`szempont_id`)) GROUP BY `screening`.`nev` ;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
