
# (1) -->  Area of a Circle
def area_of_circle():
    radius = float(input("Enter the radius of the circle: "))
    area = 3.14159 * radius ** 2
    print(f"Area of the circle is: {area:.2f}")

# (2) -->  Check if Number is Odd or Even
def check_odd_even():
    num = int(input("Enter a number: "))
    if num % 2 == 0:
        print("The number is Even.")
    else:
        print("The number is Odd.")

# (3) -->  Sum of Three Integers (Zero if Two are Equal)
def special_sum_three_numbers():
    a = int(input("Enter first number: "))
    b = int(input("Enter second number: "))
    c = int(input("Enter third number: "))
    if a == b or b == c or a == c:
        print("Sum is 0 (two or more values are equal).")
    else:
        print("Sum is:", a + b + c)

# (4) -->  Natural Numbers Summation Pattern
def natural_numbers_summation_pattern():
    total = 0
    n = int(input("Enter the number of natural numbers: "))
    total = (n * (n + 1)) // 2
    print(f"Sum of natural numbers from 1 to {n} is: {total}")

# (5) -->  Check Prime Number
def check_prime():
    num = int(input("Enter a number: "))
    if num <= 1:
        print("Not a prime number.")
        return
    for i in range(2, int(num ** 0.5) + 1):
        if num % i == 0:
            print("Not a prime number.")
            return
    print("It is a prime number.")

# (6) -->  First 16 Powers of 2 Starting from 1
def powers_of_two():
    print("First 16 powers of 2 starting with 1:")
    for i in range(16):
        print(2 ** i, end=' ')
    print()

# (7) -->  Print All Even Numbers from 1 to n
def even_numbers_range():
    n = int(input("Enter the upper limit (n): "))
    print(f"Even numbers from 1 to {n}:")
    for i in range(2, n + 1, 2):
        print(i, end=' ')
    print()

# Main Execution Area
if __name__ == "__main__":
    print("\n--- Running LAB 1 Assignments ---\n")
    area_of_circle()
    check_odd_even()
    special_sum_three_numbers()
    natural_numbers_summation_pattern()
    check_prime()
    powers_of_two()
    even_numbers_range()
