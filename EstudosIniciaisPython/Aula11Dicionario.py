#Criar dicionario
"""dicionario = {'nome': 'Braian', 'idade': 26, 'altura': 1.77}

print(dicionario['idade'])
"""

#Atribuir elemento em dicionario
"""dicionario = {'nome': 'Braian', 'idade': 26, 'altura': 1.77}

dicionario ['programador'] = True

print(dicionario)

dicionario['altura'] = 2

print(dicionario)"""

#Iterando sobre um dicionario
dicionario = {'nome': 'Braian', 'idade': 26, 'altura': 1.77}
for variavel in dicionario:
    print(variavel)

for chave in dicionario:
    print(chave, dicionario[chave])

#Saber se chave existe
print('peso' in dicionario)
print('altura' in dicionario)