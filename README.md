# Tibia Team Hunt Queuer

Tibia team hunt queuer is a work in progress application made to unite Tibia players around the world that have a hard time finding people to hunt with. Players add their characters to our system and queue up to find a team to hunt with, the application does the rest of the work. Whenever a solid team has been gathered by the system the player will be notified just like many other queuing systems in other games.

## Installation

Make sure you replace the chromedriver.exe file located in Models to use the same version of chrome that you have from: [here](http://chromedriver.storage.googleapis.com/index.html) in order for selenium to work properly. Selenium is used to be able to parse the Tibia-website, bypassing their cloudflare protection.

To get a fresh DB after cloning the repository just run the following two commands in the Package Manager Console.
```bash
Add-Migration Initial
```

```bash
Update-Database
```

## Usage
There are several endpoints that can be called for different sorts of purposes, here is what we have support for at the moment:

#### TibiaCharacter
```JSON
GetTibiaCharacter: /api/character/:id [GET]

AddTibiaCharacter: /api/character [POST]
{
    "name": "Some Player",
    "guild": "Some Guild",
    "vocation": "Elder Druid",
    "level": 310,
    "world": "Antica"
}

UpdateTibiaCharacter: /api/character [PUT]
{
	"name": "Some Player",
	"vocation": "Elder Druid",
	"guild": "Some Guild",
	"level": 310,
	"world": "Antica"
}

DeleteTibiaCharacter: /api/character/:id [DELETE]

```

#### CharacterList
```JSON
GetCharacterList: /api/characterlist/:id [GET]

CreateCharacterList: /api/characterlist [POST] => passes in accountId as body

AddTibiaCharacterToList: /api/characterlist/:characterListId/character [POST]
{
	"name": "Some Player",
	"vocation": "Elder Druid",
	"guild": "Some Guild",
	"level": 310,
	"world": "Antica"
}

RemoveCharacterList: /api/characterlist/:id [DELETE]

RemoveTibiaCharacterFromList: /api/characterlist/:characterListId/character [DELETE] => passes in characterId as body



```


#### Account
Still to be developed, for now unsecure and just there for the purpuse to be able to develop everything else.

## Contributing
Pull requests are always welcome. If you have any incentives to change the structure of something or change the direction of where something is going then please open an issue for a discussion.

When adding new pull requests, always add unit-tests accordingly for the new code / code changes you have made.

## License
[MIT](https://choosealicense.com/licenses/mit/)