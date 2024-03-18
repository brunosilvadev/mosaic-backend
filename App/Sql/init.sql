--docker run --name canvasdb -e MYSQL_ROOT_PASSWORD='Vo~qU!5bnm96TEA.YN?g' -p 3306:3306 -d mysql:latest


CREATE DATABASE canvas

--
USE canvas

CREATE TABLE Canvas (
    CanvasId INT AUTO_INCREMENT PRIMARY KEY
);

CREATE TABLE Pixels (
    PixelId INT AUTO_INCREMENT PRIMARY KEY,
    X INT NOT NULL,
    Y INT NOT NULL,
    HexColor VARCHAR(7) NOT NULL,
    CanvasId INT NOT NULL
);

