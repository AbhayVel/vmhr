






-- Table structure for table application
--

CREATE TABLE application (
  id int  NOT NULL identity(1,1),
  firstname varchar(100) NOT NULL,
  middlename varchar(100) NOT NULL,
  lastname varchar(100) NOT NULL,
  gender varchar(10) NOT NULL,
  email varchar(100) NOT NULL,
  contact varchar(50) NOT NULL,
  address text NOT NULL,
  cover_letter text NOT NULL,
  position_id int  NOT NULL,
  resume_path text NOT NULL,
  process_id tinyint  NOT NULL DEFAULT 0 ,
  date_created datetime NOT NULL DEFAULT current_timestamp
) ;

--
-- Dumping data for table application
--

--INSERT INTO application (id, firstname, middlename, lastname, gender, email, contact, address, cover_letter, position_id, resume_path, process_id, date_created)
--VALUES

-- --------------------------------------------------------

--
-- Table structure for table recruitment_status
--

CREATE TABLE recruitment_status (
  id int  NOT NULL identity(1,1),
  status_label varchar(200) NOT NULL,
  status tinyint  NOT NULL DEFAULT 1
) ;

--
-- Dumping data for table recruitment_status
--

INSERT INTO recruitment_status (  status_label, status) VALUES
('For Initial Interview', 1),
('PASSED II', 1),
('FAILED II', 1),
('For Final Interview', 1),
('PASSED FI', 1),
('FAILED FI', 1),
('FOR POOLING', 1),
('Job Offer', 1),
('Hired', 1),
( 'Withdraw Application', 1);

-- --------------------------------------------------------

--
-- Table structure for table system_settings
--

CREATE TABLE system_settings (
  id int  NOT NULL identity(1,1),
  name text NOT NULL,
  email varchar(200) NOT NULL,
  contact varchar(20) NOT NULL,
  cover_img text NOT NULL,
  about_content text NOT NULL
) ;

--
-- Dumping data for table system_settings
--

--INSERT INTO system_settings (id, name, email, contact, cover_img, about_content) VALUES

-- --------------------------------------------------------

--
-- Table structure for table users
--

CREATE TABLE users (
  id int  NOT NULL identity(1,1),
  name varchar(200) NOT NULL,
  address text NOT NULL,
  contact text NOT NULL,
  username varchar(100) NOT NULL,
  password varchar(200) NOT NULL,
  type tinyint  NOT NULL DEFAULT 2  
) ;

--
-- Dumping data for table users
--

--INSERT INTO users ( name, address, contact, username, password, type) VALUES
--(1, 0, 'Administrator', '', '', 'admin', 'admin123', 1);

-- --------------------------------------------------------

--
-- Table structure for table vacancy
--

CREATE TABLE vacancy (
  id int  NOT NULL identity(1,1),
  position varchar(200) NOT NULL,
  availability int  NOT NULL,
  description text NOT NULL,
  status tinyint  NOT NULL DEFAULT 1,
  date_created datetime NOT NULL DEFAULT current_timestamp
);

--
-- Dumping data for table vacancy
--

--INSERT INTO vacancy (id, position, availability, description, status, date_created) VALUES

-- Indexes for dumped tables
--

--
-- Indexes for table application
--
ALTER TABLE application
  ADD PRIMARY KEY (id);

--
-- Indexes for table recruitment_status
--
ALTER TABLE recruitment_status
  ADD PRIMARY KEY (id);

--
-- Indexes for table system_settings
--
ALTER TABLE system_settings
  ADD PRIMARY KEY (id);

--
-- Indexes for table users
--
ALTER TABLE users
  ADD PRIMARY KEY (id);

--
-- Indexes for table vacancy
--
ALTER TABLE vacancy
  ADD PRIMARY KEY (id);

--
-- AUTO_INCREMENT for dumped tables
--

 