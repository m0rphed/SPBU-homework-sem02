**Задача №4.1**:
	Решить задачу о вычислении выражения по дереву разбора из прошлого семестра.
	Реализовать иерархию классов, описывающих дерево разбора,
	используя их, реализовать класс, вычисляющий значение выражения по дереву.
	Классы, представляющие операнды и операторы, должны сами уметь себя вычислять и печатать.

	*Исходное условие*:
		По дереву разбора арифметического выражения вычислить его значение.
		Дерево разбора хранится в файле в виде (<операция> <операнд1> <операнд2>),
		где <операнд1> и <операнд2> сами могут быть деревьями, либо числами.
		
		Например, выражение (1 + 1) * 2 представляется в виде (* (+ 1 1) 2).
		Должны поддерживаться операции +, -, *, / и целые числа в качестве аргументов.
		Требуется построить дерево в явном виде, распечатать его (не обязательно так же, как в файле),
		и посчитать значение выражения обходом дерева.
		
		Может быть полезна функция ungetc (если не '(', возвращаем символ в поток и читаем число fscanf-ом).
		Можно считать, что входной файл корректен.
		*Пример - по входному файлу (* (+ 1 1) 2) может печататься ( * ( + 1 1 ) 2 ) и выводиться 4*.

		Ideas:

		enum State {
			WaitingExpression,
			WaitingOperatorSymbol
			WaithingNumber
			WaitingEndNumber
		}

		State myState = State.WaitingExpression

				TreeNode left ;
				TreeNode right ;
				operatorType;
				while (running){
			char x = q.pop() 
			
			switch(x) {
			  case '(':
			     ...

			    break;
			  case '+':
			    of(myState != State.WaitingOperatorSymbol) { throw ...}
				myOperator = x
				TreeNode left = CreateNode(q);
				TreeNode right = CreateNode(q);
				myState = State.WaitingEndExpression;


				( + ( - 5 8 ) 7 )
				  " ( - 5 8 ) 7 )"
				       "5 8 ) 7 )"
				        " 8 ) 7 )"
				          " ) 7 )"

				myState = State.WaitingEndExpression;
				break''
				case ')":
				 if (state == ... waitingEndExpression)"' 
				  return new Plus or Munus (left,right)
 			}
		}
		

		class TreeNode
		{
			virtual int Calculate()
			virtual void Print(StringBuilder)
		}

		class Operator : TreeNode
		{
			TreeNode left;
			TreeNode right;
			override Calculate()
		}

		class Operand : TreeNode
		{	
			int Value { public get; };
			override Calculate()
		}