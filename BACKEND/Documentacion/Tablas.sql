
CREATE TABLE persona_tipo_documento
(
    id INT AUTO_INCREMENT,
    codigo VARCHAR(20) NOT NULL,
    descripcion VARCHAR(50) NOT NULL,
	/*CAMPOS DE AUDITORIA*/
    user_create INT NOT NULL,
    user_update INT NULL,
    date_created TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    date_update TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
	PRIMARY KEY (id)
);


CREATE TABLE persona
(
	id int AUTO_INCREMENT,
	id_tipo_documento int not null,
	nombres varchar(100),
	apellido_paterno varchar(100),
	apellido_materno varchar(100),
	direccion varchar(300),
	telefono varchar(30),
	user_create INT NOT NULL,
    user_update INT NULL,
    date_created TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    date_update TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
	PRIMARY KEY (id),
	CONSTRAINT fk_persona_tipo_documento FOREIGN KEY (id_tipo_documento) REFERENCES persona_tipo_documento(id)
);


CREATE DATABASE cine_db;
USE cine_db;

CREATE TABLE genero_pelicula (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre_genero VARCHAR(50) NOT NULL,
    descripcion VARCHAR(150),
    user_create INT NOT NULL,
    user_update INT NULL,
    date_created TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    date_update TIMESTAMP NULL DEFAULT NULL
        ON UPDATE CURRENT_TIMESTAMP
);

CREATE TABLE pelicula (
    id INT AUTO_INCREMENT PRIMARY KEY,
    id_genero_pelicula INT NOT NULL,
    titulo VARCHAR(150) NOT NULL,
    director VARCHAR(100),
    anio_estreno YEAR,
    duracion_minutos INT,
    user_create INT NOT NULL,
    user_update INT NULL,
    date_created TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    date_update TIMESTAMP NULL DEFAULT NULL
        ON UPDATE CURRENT_TIMESTAMP,

    CONSTRAINT fk_pelicula_genero
        FOREIGN KEY (id_genero_pelicula)
        REFERENCES genero_pelicula(id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE
);




