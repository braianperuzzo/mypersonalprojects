# Quarta Aula : CONVERSÃO DE TIPOS

#int: inteiro
#float: numeros reais com partes decimais
#str: string / texto
#bool: valores lógicos: True ou False

idade = '26'
numero1 = '10'
numero2 = '20'
print(numero1 + numero2)
print(int(numero1) + int(numero2))

numero1_inteira = int(numero1)
numero2_inteira = int(numero2)

print(numero1_inteira + numero2_inteira)

altura = float(input('Informe a sua altura: '))

print(altura, type(altura))