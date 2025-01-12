# Documentation du Projet : Système de Gestion de Livres

## Introduction
Le projet est un **Système de Gestion de Livres** développé en C#. Ce programme permet aux utilisateurs de gérer une collection de livres via une interface en ligne de commande. Les fonctionnalités incluent l'ajout, la recherche, la sauvegarde et le chargement de livres, ainsi que leur exportation et importation au format JSON. L'objectif est de fournir un outil simple pour organiser une bibliothèque personnelle.

### Données utilisées
Chaque livre dans le système est représenté par les données suivantes :
- **Titre (Title)** : Le titre du livre.
- **Auteur (Author)** : L'auteur du livre.
- **Genre (Genre)** : La catégorie ou le genre du livre, basé sur un ensemble prédéfini (par exemple : Fiction, Romance, Fantasy).
- **Année de publication (Publication Year)** : L'année où le livre a été publié.

Les données sont soit saisies directement par l'utilisateur via des commandes, soit importées à partir de fichiers structurés tels que des fichiers CSV ou JSON.

### Pré-traitement des données
Les données importées (depuis des fichiers CSV ou JSON) sont automatiquement nettoyées et validées avant d'être ajoutées à la collection. Par exemple :
- Les genres invalides sont automatiquement convertis en "Unknown".
- Les lignes de données mal formatées sont ignorées et signalées à l'utilisateur.

---

## Liste des Commandes
Voici toutes les commandes disponibles dans le programme. Chaque commande inclut une description, les arguments nécessaires, et leur comportement détaillé.

### 1. `add`
**Description** : Ajoute un nouveau livre à la collection.

**Usage** :
```bash
add <title> <author> <genre> [publicationYear]
```
- **Arguments nécessaires** :
  - `<title>` : Le titre du livre (exemple : "Pride and Prejudice").
  - `<author>` : Le nom de l'auteur (exemple : "Jane Austen").
  - `<genre>` : Le genre du livre (exemple : "Fiction", "Romance").
- **Argument optionnel** :
  - `[publicationYear]` : L'année de publication (exemple : 1813).

**Exemple** :
```bash
add "The Great Gatsby" "F. Scott Fitzgerald" Fiction 1925
```

### 2. `search`
**Description** : Recherche des livres dans la collection par titre, auteur ou genre.

**Usage** :
```bash
search <title|author|genre> <value>
```
- **Arguments nécessaires** :
  - `<title|author|genre>` : Le type de recherche (par titre, auteur ou genre).
  - `<value>` : La valeur à rechercher.

**Exemple** :
```bash
search title "The Great Gatsby"
search author "Jane Austen"
search genre Fiction
```

### 3. `save`
**Description** : Sauvegarde tous les livres dans un fichier texte (CSV).

**Usage** :
```bash
save <filePath>
```
- **Arguments nécessaires** :
  - `<filePath>` : Le chemin complet ou relatif du fichier de sortie.

**Exemple** :
```bash
save Data/books.csv
```

### 4. `load`
**Description** : Charge des livres à partir d'un fichier texte (CSV).

**Usage** :
```bash
load <filePath>
```
- **Arguments nécessaires** :
  - `<filePath>` : Le chemin complet ou relatif du fichier source.

**Exemple** :
```bash
load Data/books.csv
```

### 5. `write_json`
**Description** : Sauvegarde tous les livres dans un fichier JSON.

**Usage** :
```bash
write_json <filePath>
```
- **Arguments nécessaires** :
  - `<filePath>` : Le chemin complet ou relatif du fichier de sortie.

**Exemple** :
```bash
write_json Data/books.json
```

### 6. `read_json`
**Description** : Charge des livres à partir d'un fichier JSON.

**Usage** :
```bash
read_json <filePath>
```
- **Arguments nécessaires** :
  - `<filePath>` : Le chemin complet ou relatif du fichier source.

**Exemple** :
```bash
read_json Data/books.json
```

### 7. `help`
**Description** : Affiche une liste de toutes les commandes disponibles avec leurs descriptions.

**Usage** :
```bash
help
```

**Exemple** :
```bash
help
```

### 8. `exit`
**Description** : Quitte le programme.

**Usage** :
```bash
exit
```

**Exemple** :
```bash
exit
```

---

## Conclusion
Ce projet met en œuvre diverses notions techniques de programmation en C#, telles que l'héritage, les exceptions personnalisées, les collections, les propriétés et l'utilisation de bibliothèques du framework .NET. Il constitue un exemple pratique de gestion de données structurées dans une application console.

