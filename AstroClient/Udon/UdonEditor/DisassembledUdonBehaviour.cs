namespace AstroClient
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using VRC.Udon;
	using VRC.Udon.Common.Interfaces;

	public class DisassembledUdonBehaviour
	{
		public IUdonProgram IUdonProgram { get; set; }
		public IUdonSymbolTable IUdonSymbolTable { get; set; }
		public IUdonHeap IUdonHeap { get; set; }

		public DisassembledUdonBehaviour(IUdonProgram IUdonProgram, IUdonSymbolTable IUdonSymbolTable, IUdonHeap IUdonHeap)
		{
			this.IUdonProgram = IUdonProgram;
			this.IUdonSymbolTable = IUdonSymbolTable;
			this.IUdonHeap = IUdonHeap;
		}
	}
}
