#Criando as próprias funções

# def - define uma função

"""def saudacao():
    print('Seja bem vindo(a)!')
    print('É um prazer ter você aqui.')
"""

"""def saudacao(nome):
    print(f'Seja bem vindo(a), {nome} !')
    print('É um prazer ter você aqui.')

saudacao('Braian')"""

"""def saudacao(nome, curso):
    print(f'Seja bem vindo(a), {nome} !')
    print(f'É um prazer ter você fazendo parte do curso de {curso}.')

saudacao('Braian', 'Python')"""

"""def saudacao(nome, curso = 'Python'):
    print(f'Seja bem vindo(a), {nome} !')
    print(f'É um prazer ter você fazendo parte do curso de {curso}.')

saudacao('Braian')"""

"""def soma(num1, num2):
    return num1 + num2

resultado = soma(5, 7)

print('O rsultado da soma é', resultado)"""

def calculadora(num1, num2, operacao = '-'):
    if(operacao == "+"):
        return num1 + num2
    elif(operacao == "-"):
        return num1 - num2

resultado = calculadora(10, 20)

print(resultado)