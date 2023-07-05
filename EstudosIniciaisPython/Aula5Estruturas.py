"""
idade = input("Qual sua idade? ")

if int(idade) < int('18'):
    print("Você é menor de idade!")
else:
    print("Você é maior de idade!")
"""

nota1 = float(input("Digite a primeira nota: "))
nota2 = float(input("Digite a segunda nota: "))
nota3 = float(input("Digite a terceira nota: "))
presenca = int(input("Digite o percentual de presença: "))

media = float((nota1 + nota2 + nota3) / int(3))

if media >= 7 and presenca >= 70:
    conceito = "Aprovado(a)"
elif media >= 5 and presenca >= 70:
    conceito = "Em Recuperação"
else:
    conceito = "Reprovado(a)"

print("Sua nota 1 foi:", nota1)
print("Sua nota 2 foi:", nota2)
print("Sua nota 3 foi:", nota3)

if media >= 5:
    print("Você está", conceito, "com média", media, "e presença de", presenca, "%")
else:
    print("E você foi", conceito, "com média", media, "e presença de", presenca, "%")

