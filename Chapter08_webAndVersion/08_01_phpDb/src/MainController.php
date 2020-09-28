<?php
namespace Mattsmithdev;


class MainController
{
    private $playerRepository;

    public function __construct()
    {
        $this->playerRepository = new PlayerRepository();
    }

    public function home()
    {
        require_once __DIR__ . '/../templates/homepage.php';
    }

    public function listPlayers($format)
    {
        $players = $this->playerRepository->findAll();

        if(empty($players)){
            $message = 'sorry - there are no player scores in the database';
            require_once __DIR__ . '/../templates/message.html.php';
        } else {
            switch ($format){
                case 'txt':
                    require_once __DIR__ . '/../templates/list.txt.php';
                    break;
                case 'json':
                    require_once __DIR__ . '/../templates/list.json.php';
                    break;
                case 'xml':
                    require_once __DIR__ . '/../templates/list.xml.php';
                    break;
                case 'html':
                default:
                    require_once __DIR__ . '/../templates/list.html.php';
            }
        }
    }

    public function insert($username, $score)
    {
        $success = $this->playerRepository->insert($username, $score);

        $message = 'failure';
        if($success){
            $message = 'success';
        }

        print $message;
    }

    public function update($username, $score)
    {
        // default - assume failed
        $success = false;

        $player = $this->playerRepository->findByUsername($username);
        if(!empty($player)){
            $oldScore = $player->getScore();
            if($score > $oldScore){
                $success = $this->playerRepository->update($username, $score);
            }
        }

        if($success){
            print 'success';
        } else {
            print -1;
        }

    }

    public function get($username, $format)
    {
        $player = $this->playerRepository->findByUsername($username);

        if(empty($player)){
            $message = 'sorry - no value could be found for username = ' . $username;
            require_once __DIR__ . '/../templates/message.html.php';
        } else {
            switch($format){
                case 'txt':
                    print $player->getScore();
                    break;
                case'html':
                default:
                require_once __DIR__ . '/../templates/show.html.php';
            }
        }
    }

    public function resetDatabase()
    {
        $this->playerRepository->resetDatabase();

        $message = 'database has been reset';
        require_once __DIR__ . '/../templates/message.html.php';
    }

}
