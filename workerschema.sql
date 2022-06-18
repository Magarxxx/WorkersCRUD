-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 20 Lut 2022, 19:43
-- Wersja serwera: 10.4.21-MariaDB
-- Wersja PHP: 8.0.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `workerschema`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `worker_table`
--

CREATE TABLE `worker_table` (
  `id` int(11) NOT NULL,
  `firstName` varchar(45) DEFAULT NULL,
  `lastName` varchar(45) DEFAULT NULL,
  `position` varchar(45) DEFAULT NULL,
  `salary` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `worker_table`
--

INSERT INTO `worker_table` (`id`, `firstName`, `lastName`, `position`, `salary`) VALUES
(1, 'Jan', 'Nowak', 'Kierownik', 6500),
(2, 'Mateusz', 'Kwiatek', 'Operator', 5000),
(3, 'Krzystof', 'Huk', 'Operator', 5100),
(4, 'Zofia', 'Fiołek', 'Ksiegowa', 5500),
(5, 'Sebastian', 'Koło', 'Kierowca', 3500),
(6, 'Jan', 'Mazur', 'Obsługa', 3500),
(7, 'Barbara', 'Warcaba', 'Obsługa', 3600),
(8, 'Robert', 'Malik', 'Kierowca', 4800);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `worker_table`
--
ALTER TABLE `worker_table`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `worker_table`
--
ALTER TABLE `worker_table`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
