![Mosad](mosad.png)

# 🐾 Útulek pro zvířata – konzolová aplikace (C#)

Týmový projekt – konzolová aplikace v jazyce **C#**, která slouží k evidenci zvířat v útulku.  
Aplikace umožňuje přidávání, výpis, vyhledávání, adopci a práci s daty uloženými v paměti (`List<T>`),  
volitelně také ukládání a načítání dat ze souboru.

---

## 🎯 Cíle projektu
- Procvičení OOP v C#
- Práce s kolekcemi (`List<Zvire>`)
- Oddělení logiky aplikace (Model / Services / UI)
- Základní validace vstupů
- Týmová spolupráce pomocí Git větví a Pull Requestů

---

## 📋 Funkční požadavky

### 1️⃣ Přidání zvířete
Každé zvíře obsahuje tyto vlastnosti:
- **ID** (automaticky generované)
- **Jméno**
- **Druh** (pes / kočka / jiné)
- **Věk** (roky, číslo ≥ 0)
- **Pohlaví**
- **Datum příjmu**
- **Zdravotní stav**
- **Poznámka**
- **Adoptováno** (ano / ne)
- **Datum adopce** (pokud je adoptováno)

---

### 2️⃣ Výpis všech zvířat
- Přehledný tabulkový výpis v konzoli
- Zobrazení základních údajů (ID, jméno, druh, věk, adopce)

---

### 3️⃣ Vyhledávání / filtrování
Možnosti filtru:
- podle **druhu**
- podle **věku** (≤ / ≥)
- podle **jména** (obsahuje text)

---

### 4️⃣ Označení adopce
- Nastavení stavu „adoptováno“
- Uložení **data adopce**

---

### 5️⃣ Validace vstupů
- Věk musí být číslo ≥ 0
- Nepovinné položky mohou zůstat prázdné
- Ošetření neplatných vstupů z konzole

---

## ⭐ Rozšíření (volitelné)

- 📊 **Statistiky**
  - počet zvířat podle druhu
  - průměrný věk
  - počet adoptovaných zvířat
- ✏️ **Editace a mazání zvířete**
- 📄 **Export karty zvířete do TXT**
- 💾 **Načítání a ukládání dat do souboru**
- 🔁 **Přednačtení testovacích dat**

---

## 👥 Týmová spolupráce

- Každá funkce ve vlastní **větvi**
- Sloučení změn výhradně přes **Pull Request**
- Kontrola kódu alespoň jedním členem týmu

---

## 🛠️ Technologie
- C# (.NET)
- Konzolová aplikace
- Git + GitHub

---

## 📌 Poznámky
- Zvířata jsou ukládána do `List<Zvire>`
- Data lze volitelně ukládat do souboru
- Projekt je připraven na další rozšiřování
