# Credits
This project is made possible by project [parking-lot](https://github.com/dreamhead/parking-lot) by [Zheng Ye](https://github.com/dreamhead).

This project is project [parking-lot](https://github.com/dreamhead/parking-lot), which is in Java language, rewritten with C# language and xUnit.

# Parking Lot 练习题

## 简介

Parking Lot 是 OO BootCamp 的练习题。

* 第一步：停车和取车
* 第二步：停车小弟管理着两个停车场：第一个停满之后，停第二个
* 第三步：停车小弟管理着两个停车场：停到空位最多的停车场
* 第四步：停车小弟管理着两个停车场：停到空位最少的停车场
* 第五步：停车场管理员，他可以管理停车场和小弟
* 第六步：停车场超级管理员，他可以管理停车场和停车场管理员或小弟
* 第七步：打印停车场、停车小弟、停车管理员以及超级管理员的状态报告，展示其管理的详细车位情况

# Notes
Following design changes has been made.
## Redesigned BaseParkingBoyTest class and its derived classes
Base on the following two facts, the BaseParkingBoyTest has been slightly redesigned instead of purely rewritten from its [Java counterparts](https://github.com/dreamhead/parking-lot/commit/c095a364d0289bd2881fec7a6949c69a3370388e#diff-536ec9c6d90e1b828901e40c6bbb064385264e45fe6c01e407587d73fc17f63e).
1. [xUnit per test setup is defined in test constructor](#xunit-per-test-setup-is-defined-in-test-constructor)
2. [It is inappropriate to call overriden method in base class constructor](#it-is-inappropriate-to-call-overridable-method-in-base-class-constructor)
### xUnit per test setup is defined in test constructor
As suggested in the [xUnit document](https://xunit.net/docs/shared-context), shared setup code is defined in test class constructor.
### It is inappropriate to call overridable method in base class constructor
Is C#, the execution flow of a derived class is in following order as it is suggested in [Eric Lippert's post](https://learn.microsoft.com/en-us/archive/blogs/ericlippert/why-do-initializers-run-in-the-opposite-order-as-constructors-part-one):
1. derived class initializer
2. base class initializer
3. base class constructor
4. derived class constructor,

If you call a virtual member from the constructor in a base type, each override of this virtual member in a derived type will be executed before the constructor of the derived type is called.
And if the override in the derived type uses its members, this can lead to confusion and / or errors.