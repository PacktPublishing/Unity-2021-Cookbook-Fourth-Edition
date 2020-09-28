<?php
namespace Mattsmithdev;

class Database
{
	private $dbLocation = __DIR__ . DIRECTORY_SEPARATOR . '..' . DIRECTORY_SEPARATOR . 'data/leadboard.sqlite3';
    private $pdo;

    public function __construct()
    {
        $dsn = 'sqlite:' . $this->dbLocation;
        $this->pdo = new \PDO($dsn);
    }

    public function getConnection()
    {
        return $this->pdo;
    }

}
