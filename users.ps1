("mwhelan","kmaddocks","alexisatkinson","bstayte","Zaralus","mager18","bedfordn","gtejeda","Eothain","mthadisena") | foreach-object{
  git remote add $_ "git://github.com/$_/nbdn.git" 
}
