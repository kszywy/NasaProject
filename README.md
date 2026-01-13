# Nasa Weather

## Opis projektu

Aplikacja wykorzystuje bazę danych zawierającą informacje o zjawiskach pogodowych w kosmosie i na Ziemi aby użytkownik był w stanie zobaczyć jaka pogoda była danego dnia jednocześnie w prestrzeni kosmicznej, jak i na naszej planecie. Dodatkowo, użytkownik może podejrzeć zdjęcie Astronomy Picture Of The Day na podstawie daty którą wybrał.

## Funkcjonalności

- **Eksport danych z bazy danych do formatów JSON, XML i SQL**
- **Import danych do bazy danych za pomocą formatów JSON, XML i SQL**
- **Przegląd danych z danego dnia za pośrednictwem GUI**

## Technologie

- **Język programowania**: C#, MySQL

## Struktura projektu

- **Nasa/**: Główny katalog, wszystykie pliki i foldery wskazane poniżej znajdują się w nim
- **resources/**: Katalog zawierający pliki źródłowe, umożliwiające zapełnienie bazy danych
- **APODConnections.cs**: Plik odpowiedzialny za wykonywanie zapytań do API APOD
- **DbConnection.cs**: Klasa odpowiedzialna za łączenie się z bazą danych
- **DbCreator.cs**: Klasa odpowiedzialna za tworzenie bazy danych i jej import
- **Earthweather.cs, SpaceWeather.cs**: Klasy przechowujące dane pochodzące z jednego wiersza odpowiedniej tabeli

## Wymagania

- .NET w wesji 8.0
- Visual Studio 2022
- System Windows 10 lub 11
- Dowolna współczesna przeglądarka internetowa
- XAMPP

## Narzędzia i biblioteki


## Źródła danych

- [NASA\_space\_weather\_data \| Kaggle](https://www.kaggle.com/datasets/edacelikeloglu/nasa-space-weather-data?resource=download&select=cme_dataset_metadata.json) - dane od 11-07-2023
- [World Weather Repository ( Daily Updating ) \| Kaggle](https://www.kaggle.com/datasets/nelgiriyewithana/global-weather-repository?select=GlobalWeatherRepository.csv) - dane od 29-08-2023, pobrane dnia 21-12-2025
- [GitHub - nasa/apod-api: Astronomy Picture of the Day API service](https://github.com/nasa/apod-api?tab=readme-ov-file#docs)

## Uruchomienie

1. Zawartość pliku .zip należy rozpakować do dowolnego folderu w systemie Windows do których użytkownik posiada odpowiednie uprawnienia
2. Uruchom pakiet XAMP - serwery Apache i MySQL na porcie 3306
3. Otwórz plik *NasaProject.sln* za pośrednictwem opcji `Open Project or Solution` w programie Visual Studio
4. Zbuduj i skompiluj aplikację
5. Jeśli uruchamiasz aplikację po raz pierwszy, nie posiadasz odpowiedniej bazy danych do pracy z aplikacją. Aby to zmienić, użyj przycisku `Utwórz bazę danych` i utwórz bazę danych o nazwie `weather`.

## Autorzy

Projekt został stworzony przez Martynę Dębowczyk oraz Wojciecha Cioczka.