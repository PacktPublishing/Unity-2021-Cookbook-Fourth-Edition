<?php
namespace Mattsmithdev;


class PlayerRepository
{
    private $connection;

    public function __construct()
    {
        $db = new Database();
        $this->connection = $db->getConnection();
    }

    /**
     * drop table, then re-create
     * then insert our default data
     */
    public function resetDatabase()
    {
        $this->dropTable();
        $this->createTable();
        $this->loadFixtures();
    }
    
    public function loadFixtures()
    {
        $this->insert('matt', 500);
        $this->insert('jane', 101);
        $this->insert('jim', 99);
        $this->insert('amy-jane', 88);
        $this->insert('ray', 77);
    }

    public function dropTable()
    {
        $sql = 'DROP TABLE IF EXISTS player';
        $this->connection->exec($sql);
    }

    public function createTable()
    {

        $sql = '
                CREATE TABLE IF NOT EXISTS  player (
                  id INTEGER PRIMARY KEY,
                  username varchar(25) NOT NULL,
                  score INTEGER NOT NULL
                  )
            ';

        $this->connection->exec($sql);
    }

    public function insert($username, $score)
    {
        // Prepare INSERT statement to SQLite3 file db
        $sql = 'INSERT INTO player (username, score) 
			VALUES (:username, :score)';
        $stmt = $this->connection->prepare($sql);

        // Bind parameters to statement variables
        $stmt->bindParam(':username', $username);
        $stmt->bindParam(':score', $score);

        // Execute statement
        $stmt->execute();

        $rowsChanged = $stmt->rowCount();

        // true if a row was changed - i.e. successful insert
        return ($rowsChanged > 0);
    }

    public function update($username, $score)
    {
        // Prepare INSERT statement to SQLite3 file db
        $sql = 'UPDATE player SET score = :score
			WHERE username = :username';
        $stmt = $this->connection->prepare($sql);

        // Bind parameters to statement variables
        $stmt->bindParam(':username', $username);
        $stmt->bindParam(':score', $score);

        // Execute statement
        $stmt->execute();

        $rowsChanged = $stmt->rowCount();

        // true if a row was changed - i.e. successful insert
        return ($rowsChanged > 0);
    }


    public function findAll()
    {
        $sql = 'SELECT * FROM player ORDER BY score DESC';

        $stmt = $this->connection->prepare($sql);
        $stmt->execute();
        $stmt->setFetchMode(\PDO::FETCH_CLASS, '\\Mattsmithdev\\Player');

        $players = $stmt->fetchAll();

        return $players;
    }

    public function findAllAsArray()
    {
        $sql = 'SELECT * FROM player';

        $stmt = $this->connection->prepare($sql);
        $stmt->execute();
//        $stmt->setFetchMode(\PDO::FETCH_CLASS, '\\Mattsmithdev\\Player');

        $players = $stmt->fetchAll();

        return $players;
    }

    public function find($id)
    {
        $sql = 'SELECT * FROM player WHERE id = :id';

        $stmt = $this->connection->prepare($sql);
        $stmt->bindParam(':id', $id);

        // Execute statement
        $stmt->execute();
        $stmt->setFetchMode(\PDO::FETCH_CLASS, '\\Mattsmithdev\\Player');

        $product = $stmt->fetch();

        return $product;
    }

    public function findByUsername($username)
    {
        $sql = 'SELECT * FROM player WHERE username = :username';

        $stmt = $this->connection->prepare($sql);
        $stmt->bindParam(':username', $username);

        // Execute statement
        $stmt->execute();
        $stmt->setFetchMode(\PDO::FETCH_CLASS, '\\Mattsmithdev\\Player');

        $product = $stmt->fetch();

        return $product;
    }

    public function deleteAll()
    {
        $sql = 'DELETE * FROM player';

        $stmt = $this->connection->exec($sql);
    }

}
