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




