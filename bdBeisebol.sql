CREATE DATABASE if NOT exists dbBeisebol;
USE dbBeisebol;
CREATE TABLE if not exists tbTime(id_time smallint  primary key AUTO_INCREMENT, 
					NomeTime varchar(50) NOT NULL,
                    CidadeTime varchar(100) NOT NULL);
					
INSERT INTO tbTime (NomeTime,CidadeTime) VALUES ("Baltimore Orioles", "exem");
INSERT INTO tbTime (NomeTime,CidadeTime) VALUES ("Boston Red Sox", "exem");
INSERT INTO tbTime (NomeTime,CidadeTime) VALUES ("New York Yankees", "exem");
				
          
SELECT * FROM tbTime;













