# SnakeGame

Prosta gra Snake w konsoli napisana w C#.

## Jak grać
- Steruj wężem za pomocą strzałek.
- Zjadaj *, aby zdobywać punkty i wydłużać węża.
- Unikaj zderzenia ze ścianą lub samym sobą.
- Po przegranej naciśnij `R`, aby zagrać ponownie lub dowolny inny klawisz, aby wyjść.

## Wymagania
- .NET SDK 9.0

## Uruchomienie
1. Sklonuj repozytorium lub skopiuj pliki projektu.
2. Otwórz terminal w katalogu projektu.
3. Uruchom:
   ```bash
   dotnet run
   ```

## Struktura projektu
- `Program.cs` – główna logika gry
- `Pliki/Pixel.cs` – klasa segmentu węża
- `Pliki/Obstakel.cs` – klasa przeszkody

## Funkcje
- Losowe rozmieszczanie przeszkód
- Liczenie punktów
- Opcja restartu gry po przegranej

