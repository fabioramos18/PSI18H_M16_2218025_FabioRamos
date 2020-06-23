-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 23-Jun-2020 às 23:42
-- Versão do servidor: 10.4.11-MariaDB
-- versão do PHP: 7.4.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `mydb`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `consulta`
--

CREATE TABLE `consulta` (
  `idMarcacao` int(11) NOT NULL,
  `User_id_user` int(11) DEFAULT NULL,
  `nome_completo` varchar(100) NOT NULL,
  `num_saude` int(11) NOT NULL,
  `Data_nascimento` date NOT NULL,
  `contacto` int(11) NOT NULL,
  `morada` tinytext NOT NULL,
  `nome_hospital` varchar(45) NOT NULL,
  `nome_especialidade` varchar(45) NOT NULL,
  `Data_consulta` date DEFAULT NULL,
  `Medico_idMedico` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `consulta`
--

INSERT INTO `consulta` (`idMarcacao`, `User_id_user`, `nome_completo`, `num_saude`, `Data_nascimento`, `contacto`, `morada`, `nome_hospital`, `nome_especialidade`, `Data_consulta`, `Medico_idMedico`) VALUES
(9, 1, 'Nome Completo', 0, '2020-06-19', 0, 'Morada', 'Hospital Beatriz Ângelo', 'Cardiologia', '2020-06-19', 2),
(12, 1, 'Zacarias Oliveira', 7908689, '2002-03-03', 22222222, 'sao paulo', 'Hospital Da Luz', 'Fisioterapia', '2002-03-03', 2),
(16, NULL, 'Nome Completo', 0, '2020-06-19', 0, 'Morada', 'Hospital Beatriz Ângelo', 'Cardiologia', '2020-06-23', 2),
(23, NULL, 'Nome Completo', 0, '2020-06-19', 0, 'Moradafdfrf', 'Hospital Beatriz Ângelo', 'Cardiologia', '2020-06-23', 5),
(24, NULL, 'Nome Completo', 0, '2020-06-19', 0, 'Morada', 'Hospital Beatriz Ângelo', 'Cardiologia', '2020-06-19', 2),
(25, NULL, 'eerrNome Completo', 0, '2020-06-19', 0, 'Morada', 'Hospital Beatriz Ângelo', 'Cardiologia', '2020-06-27', 2),
(26, NULL, 'Nome Completoerrrrrr ', 213123123, '2020-06-19', 2132131, 'Moradaew fd', 'Hospital Beatriz Ângelo', 'Cardiologia', '2020-06-19', 2),
(29, NULL, 'fabio Ramoss', 2147483647, '2020-10-31', 2147483647, 'RUA ALBERO FITMINO 198', 'Hospital Trofa Saúde', 'Vacina', '2020-10-31', 5),
(30, NULL, 'cARLOS', 343434343, '1990-01-02', 2147483647, 'CAMPO GRANDE', 'Hospital Trofa Saúde', 'Neurologia', '1990-01-02', 2),
(31, NULL, 'FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF', 2147483647, '2020-06-01', 2147483647, 'RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR', 'Hospital Da Luz', 'Nutrição', '2021-09-28', 5),
(32, NULL, 'teste teste', 1212121221, '2020-06-03', 2147483647, 'Moradaqualquer', 'Hospital Da Luz', 'Nutrição', '2020-06-27', 5),
(33, 4, 'CristIano António dos Santos Oliveira', 2145435346, '1995-07-26', 966445244, 'Rua Cristovão Colombo,nº15, r/c', 'Hospital Trofa Saúde', 'Obsterticia', '2020-06-30', 5),
(34, NULL, 'teste teste t', 123454356, '2020-06-23', 986754673, 'lisboa', 'Hospital Trofa Saúde', 'Psicologia', '2020-06-23', 5),
(35, NULL, 'Nome Completo para teste', 34545345, '2020-06-01', 345345345, 'Morada nº12', 'Hospital Trofa Saúde', 'Nutrição', '2020-06-23', 2),
(36, NULL, 'Nome Completo tese', 2112121221, '2020-06-23', 76543235, 'rua x , 18, r/c', 'Hospital Beatriz Ângelo', 'Cardiologia', NULL, NULL),
(37, NULL, 'fafafafafafafaf', 21444325, '2020-06-01', 967967976, 'Morada morada morada', 'Hospital Beatriz Ângelo', 'Cardiologia', NULL, NULL);

-- --------------------------------------------------------

--
-- Estrutura da tabela `especialidade`
--

CREATE TABLE `especialidade` (
  `idEspecialidade` int(11) NOT NULL,
  `nome_especialidade` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `especialidade`
--

INSERT INTO `especialidade` (`idEspecialidade`, `nome_especialidade`) VALUES
(1, 'Cardiologia'),
(2, 'Dentista'),
(3, 'Fisioterapia'),
(4, 'Ginecologia'),
(5, 'Neurologia'),
(6, 'Nutrição'),
(7, 'Obsterticia'),
(8, 'Psicologia'),
(9, 'Pediatria'),
(10, 'Vacina');

-- --------------------------------------------------------

--
-- Estrutura da tabela `hospital`
--

CREATE TABLE `hospital` (
  `idHospita` smallint(5) NOT NULL,
  `nome_hospital` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `hospital`
--

INSERT INTO `hospital` (`idHospita`, `nome_hospital`) VALUES
(1, 'Hospital Beatriz Ângelo'),
(2, 'Hospital Da Luz'),
(3, 'Hospital Trofa Saúde');

-- --------------------------------------------------------

--
-- Estrutura da tabela `hospital_tem_especialidade`
--

CREATE TABLE `hospital_tem_especialidade` (
  `id` int(11) NOT NULL,
  `Especialidade_idEspecialidade` int(11) NOT NULL,
  `Hospital_idHospita` smallint(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `hospital_tem_especialidade`
--

INSERT INTO `hospital_tem_especialidade` (`id`, `Especialidade_idEspecialidade`, `Hospital_idHospita`) VALUES
(1, 1, 1),
(2, 2, 1),
(3, 3, 1),
(4, 4, 1),
(5, 5, 1),
(6, 6, 1),
(7, 3, 2),
(8, 4, 2),
(9, 5, 2),
(10, 6, 2),
(11, 7, 2),
(12, 8, 2),
(13, 5, 3),
(14, 6, 3),
(15, 7, 3),
(16, 8, 3),
(17, 9, 3),
(18, 10, 3);

-- --------------------------------------------------------

--
-- Estrutura da tabela `medico`
--

CREATE TABLE `medico` (
  `idMedico` int(11) NOT NULL,
  `nome_medico` varchar(45) NOT NULL,
  `morada` varchar(70) NOT NULL,
  `email` varchar(80) NOT NULL,
  `contacto` int(11) NOT NULL,
  `Especialidade_idEspecialidade` int(11) NOT NULL,
  `Hospital_idHospita` smallint(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `medico`
--

INSERT INTO `medico` (`idMedico`, `nome_medico`, `morada`, `email`, `contacto`, `Especialidade_idEspecialidade`, `Hospital_idHospita`) VALUES
(2, 'Pedro Santos', 'Rua principal, vale das rosas, nº 19,rc', 'fabioramos10h@gmail.com', 9789957, 1, 1),
(5, 'Rita Campos Oliveira', 'Rua das rosas, nº1, r/c, Lisboa', 'RitaCampos12@gmail.com', 966160444, 10, 3);

-- --------------------------------------------------------

--
-- Estrutura da tabela `user`
--

CREATE TABLE `user` (
  `id_user` int(11) NOT NULL,
  `nome_completo` varchar(100) NOT NULL,
  `user` varchar(60) NOT NULL,
  `email` text NOT NULL,
  `passe` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `user`
--

INSERT INTO `user` (`id_user`, `nome_completo`, `user`, `email`, `passe`) VALUES
(1, 'e', 'e', 'eeeeeeeee', 'e'),
(3, 'Vera Costa', 'VeraCosta1', 'p@monteiro.com', 'vera123'),
(4, 'CristIano António dos Santos Oliveira', 'CristIano.António', 'CristIano.António.12gmail.com', 'Cristiano123'),
(7, 'teste teste', 'teste4', 'teste12@gmail.com', 't4');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `consulta`
--
ALTER TABLE `consulta`
  ADD PRIMARY KEY (`idMarcacao`),
  ADD KEY `fk_Marcacao_Medico1_idx` (`Medico_idMedico`),
  ADD KEY `fk_Consulta_User1_idx` (`User_id_user`);

--
-- Índices para tabela `especialidade`
--
ALTER TABLE `especialidade`
  ADD PRIMARY KEY (`idEspecialidade`);

--
-- Índices para tabela `hospital`
--
ALTER TABLE `hospital`
  ADD PRIMARY KEY (`idHospita`);

--
-- Índices para tabela `hospital_tem_especialidade`
--
ALTER TABLE `hospital_tem_especialidade`
  ADD PRIMARY KEY (`id`,`Hospital_idHospita`,`Especialidade_idEspecialidade`),
  ADD KEY `fk_Hospital_has_Especialidade_Especialidade1_idx` (`Especialidade_idEspecialidade`),
  ADD KEY `fk_Hospital_has_Especialidade_Hospital1_idx` (`Hospital_idHospita`);

--
-- Índices para tabela `medico`
--
ALTER TABLE `medico`
  ADD PRIMARY KEY (`idMedico`,`Especialidade_idEspecialidade`,`Hospital_idHospita`),
  ADD KEY `fk_Medico_Especialidade1_idx` (`Especialidade_idEspecialidade`),
  ADD KEY `fk_Medico_Hospital1_idx` (`Hospital_idHospita`);

--
-- Índices para tabela `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id_user`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `consulta`
--
ALTER TABLE `consulta`
  MODIFY `idMarcacao` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=38;

--
-- AUTO_INCREMENT de tabela `especialidade`
--
ALTER TABLE `especialidade`
  MODIFY `idEspecialidade` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de tabela `hospital`
--
ALTER TABLE `hospital`
  MODIFY `idHospita` smallint(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de tabela `medico`
--
ALTER TABLE `medico`
  MODIFY `idMedico` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de tabela `user`
--
ALTER TABLE `user`
  MODIFY `id_user` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `consulta`
--
ALTER TABLE `consulta`
  ADD CONSTRAINT `fk_Consulta_User1` FOREIGN KEY (`User_id_user`) REFERENCES `user` (`id_user`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Marcacao_Medico1` FOREIGN KEY (`Medico_idMedico`) REFERENCES `medico` (`idMedico`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `hospital_tem_especialidade`
--
ALTER TABLE `hospital_tem_especialidade`
  ADD CONSTRAINT `fk_Hospital_has_Especialidade_Especialidade1` FOREIGN KEY (`Especialidade_idEspecialidade`) REFERENCES `especialidade` (`idEspecialidade`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Hospital_has_Especialidade_Hospital1` FOREIGN KEY (`Hospital_idHospita`) REFERENCES `hospital` (`idHospita`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `medico`
--
ALTER TABLE `medico`
  ADD CONSTRAINT `fk_Medico_Especialidade1` FOREIGN KEY (`Especialidade_idEspecialidade`) REFERENCES `especialidade` (`idEspecialidade`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Medico_Hospital1` FOREIGN KEY (`Hospital_idHospita`) REFERENCES `hospital` (`idHospita`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
