
![Пример работы](https://raw.githubusercontent.com/borod1nov/breed-detector/1ccfdf6be335b1cb252a598cf89e6f97771bf58a/saint_bernard_example.jpg)
# О проекте
*Программа распознает 37 пород кошек и собак*\
Полный список поддерживаемых пород:\
Собаки:
1) American bulldog	
2) American pitbull terrier	
3) Basset hound	
4) Beagle	
5) Boxer	
6) Chihuahua	
7) English cocker spaniel	
8) English setter	
9) German shorthaired	
10) Great pyrenees	
11) Havanese	
12) Japanese chin	
13) Keeshond
14) Leonberger
15) Miniature pinscher
16) Newfoundland
17) Pomeranian
18) Pug
19) Saint Bernard
20) Samoyed
21) Scottish terrier
22) Shiba inu
23) Staffordshire bull terrier
24) Wheaten terrier
25) Yorkshire terrier

Кошки:
1) Abyssinian
2) Bengal
3) Birman
4) Bombay
5) British shorthair
6) Egyptian mau
7) Maine coon
8) Persian
9) Ragdoll
10) Russian blue
11) Siamese
12) Sphynx

# Инструкция по сборке и использованию проекта
1. *Получить файл best.onnx*\
    1a. Файл можно сгенерировать с помощью [этого ноутбука](https://colab.research.google.com/drive/1SbCXfn1cGPilERDw0BXaEL_GNPP8T6wC?usp=sharing) в GPU среде Google Colab.\
    1b. Также можно [скачать](https://drive.google.com/uc?export=download&id=1AKeDjjEnoVFXkYOUDhPu-JxF_CbydGka) готовый onnx файл.\
2. *Склонировать этот репозиторий*
3. *Положить файл best.onnx в папку breed-detector/bin/Debug/net8.0-windows склонированного репозитория*
4. *Открыть в Visual Studio файл BreedDetector.sln*
5. *Запустить решение в Visual Studio*