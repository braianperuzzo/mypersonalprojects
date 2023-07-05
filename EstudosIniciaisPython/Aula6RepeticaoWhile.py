sorteio = int(15)

numero = int(input("Digite um número entre 1 e 20 para ser sorteado: "))

while sorteio != numero:
    print("Você errou! Tente Novamente")
    numero = int(input("Digite um número entre 1 e 20 para ser sorteado: "))
else:
    print("Você acertou!")

contador = 0
while contador < 5:
    print(contador)
    contador = contador + 1