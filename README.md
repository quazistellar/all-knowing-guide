----- Проводник, реализованный внутри консольного с#-приложения -----

!-- Функционал:

-> Программа начинается с выбора диска. Диски автоматически подгружаются из кода (с помощью DriveInfo).

-> Выводится информация о диске (сколько ГБ заполнено, сколько свободно).

-> Реализован выбор одного из пунктов меню (стрелочное меню в классе ArrowsMenu.cs).

-> По переходу в один из дисков отображается информация о папках и файлах внутри диска.

-> Выводится информация о папке или файле (дата создания, формат файла, название).

-> По переходу в папку отображается информация о папках и файлах внутри папки.

-> Если пользователь выбрал файл, он запускается на компьютере самостоятельно (т.е. txt через блокнот, docx - через Word и т.п.).

-> Присутствует возврат на папку выше по нажатию на клавишу Escape.

-> Дополнительный функционал для пользователя: реализована возможность создания файла, создания директории, удаление выбранного файла/директории.


!-- Структура проекта:

-> Реализован отдельный статический класс по работе с проводником - вывод папок и файлов, выбор папки, вывод дисков, выбор диска и т.п.

-> Реализован отдельный статический класс по работе со стрелками в стрелочном меню.

-> Функционал по работе с файлами (добавление/удаление) реализован в отдельном статическом классе

----------------------------------------------------------------------
