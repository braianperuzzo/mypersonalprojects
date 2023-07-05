#append - insere um elemento sempre no final da lista
lista = [1, 3, 12, 8, 2]

print("Antes do Append:", lista)

lista.append(3)

print("Depois do Append:", lista)

#insert - escolhe a posição onde o elemento será inserido
lista = [1, 3, 12, 8, 2]

print("Antes do Insert:", lista)

lista.insert(2, 10)

print("Depois do Inser:", lista)

#extend - serve para unir duas listas
lista1 = [1, 3, 12, 8, 2]
lista2 = [1, 2, 3]

print("Antes do Extend:", lista1)
print("Antes do Extend:", lista2)

lista1.extend(lista2)

print("Depois do Extend:", lista1)

#pop - remove o elemento que especificar ou o último, se não específicar
lista = [1, 3, 12, 8, 2]

print("Antes do Pop:", lista)

lista.pop(1)

print("Depois do Pop:", lista)

#remove - diz qual elemento quer remover

lista = [1, 3, 12, 8, 2]

print("Antes do Remove:", lista)

lista.remove(3) #não remove o indice, e sim apenas o primeiro item 3 que encontrar

print("Depois do Remove:", lista)

#count - conta quantos elementos x tem em uma lista
lista = [1, 3, 12, 3, 2]

print("Antes do Count:", lista)

print("Depois do Count:", lista.count(3))

#index - usa o indice de determinado elemento dentro da lista
lista = [1, 3, 12, 3, 2]

print("Antes do Index:", lista)

print("Depois do Index:", lista.index(12))

#sort - ordena a lista de forma crescente
lista = [1, 3, 12, 3, 2]

print("Antes do Sort:", lista)
lista.sort()
print("Depois do Sort:", lista)

print("Antes do Sort - Descrescente:", lista)
lista.sort(reverse = True)
print("Depois do Sort - Descrescente:", lista)

#FUNÇOES
lista = [1, 3, 12, 3, 2]

#Len - saber quantos elementos tem em uma lista
print(len(lista))

#Sum - soma todos os elementos da lista
print(sum(lista))

#Max - retorna o maior elemento da lista
print(max(lista))

#Min - retorna o menor elemento da lista
print(min(lista))