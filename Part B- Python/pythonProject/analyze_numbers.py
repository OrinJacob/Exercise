import matplotlib.pyplot as plt
import numpy as np
from scipy.stats import pearsonr


def analyze_numbers():
    list_of_numbers = list()
    user_input = get_number_from_user()

    while user_input != -1:
        list_of_numbers.append(user_input)
        user_input = get_number_from_user()

    average = calculate_average(list_of_numbers)
    print(f'The average of the numbers is {average}.')

    num_of_positive_numbers = len([num for num in list_of_numbers if num > 0])
    print(f'There are {num_of_positive_numbers} positive numbers.')

    sorted_list_of_numbers = sorted(list_of_numbers)
    print('sorted numbers: ', *sorted_list_of_numbers)

    print(f'Pearson correlation coefficient: {get_pearson_correlation_coefficient(list_of_numbers)}')

    display_input_numbers_graph(list_of_numbers)


def calculate_average(list_of_numbers: list) -> float:
    if len(list_of_numbers) == 0:
        return 0.0;

    return sum(list_of_numbers) / len(list_of_numbers)


def get_number_from_user() -> float or int:
    while True:
        try:
            num = float(input("Enter a number: "))

            if num % 1 == 0:
                num = int(num)

            return num

        except ValueError:
            print("Error: Invalid input. Please enter a valid number.")


def display_input_numbers_graph(list_of_numbers: list):
    x = np.arange(1, len(list_of_numbers) + 1)
    y = np.array(list_of_numbers)

    plt.scatter(x, y)

    plt.title('Input Data')
    plt.xlabel('Number Of Recieved Input')
    plt.ylabel('Input Value')

    plt.xticks(x)

    plt.show()


def get_pearson_correlation_coefficient(list_of_numbers: list) -> str:
    if len(list_of_numbers) < 2:
        return "'list_of_number' has less than 2 elements. Pearson correlation coefficient can't be calculated."
    x = np.arange(1, len(list_of_numbers) + 1)
    y = np.array(list_of_numbers)
    corr_coeff, p_value = pearsonr(x, y)
    return corr_coeff
