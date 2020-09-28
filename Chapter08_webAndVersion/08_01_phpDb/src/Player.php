<?php

namespace Mattsmithdev;


class Player
{
    private $id;
    private $username;
    private $score;

    public function getId()
    {
        return $this->id;
    }

    public function setId($id): void
    {
        $this->id = $id;
    }

    public function getUsername()
    {
        return $this->username;
    }

    public function setUsername($username): void
    {
        $this->username = $username;
    }

    public function getScore()
    {
        return $this->score;
    }

    public function setScore($score): void
    {
        $this->score = $score;
    }

    public function toArray() {
        return [
            'id' => $this->id,
            'username' => $this->username,
            'score' => $this->score,
        ];
    }

    public function toJson() {
        return json_encode($this->toArray());
    }


    public function __toString()
    {
        $text = '';
        $text .= '<hr>';
        $text .= '<br>Id: ' . $this->getId();
        $text .= '<br>Username: ' . $this->getUsername();
        $text .= '<br>Score: ' . $this->getScore();

        return $text;
    }
}
