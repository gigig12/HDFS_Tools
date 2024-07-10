using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Admin;

namespace CS2_ExecAfter
{
	public partial class CS2_ExecAfter
	{
		public string? exec_after_map_end;
		public string? exec_after_map_end_once;

		private void OnMapEndHandler()
		{
			if (!string.IsNullOrEmpty(exec_after_map_end))
			{
				ReplyToCommand($"Executing (map end): {exec_after_map_end}");
				Server.ExecuteCommand(exec_after_map_end);
			}
			if (!string.IsNullOrEmpty(exec_after_map_end_once))
			{
				ReplyToCommand($"Executing once (map end): {exec_after_map_end_once}");
				Server.ExecuteCommand(exec_after_map_end_once);
				exec_after_map_end_once = null;
			}
		}

		[ConsoleCommand("exec_after_map_end", "Executes a command every time the map ends")]
		[RequiresPermissions("@css/rcon")]
		public void ConVarExecAfterMapEnd(CCSPlayerController? player, CommandInfo command)
		{
			string args = command.ArgString.Trim();
			if (string.IsNullOrEmpty(args))
			{
				ReplyToCommand($"exec_after_map_end = {exec_after_map_end}", player);
				return;
			}
			args = StripQuotes(args);
			exec_after_map_end = args;
			ReplyToCommand($"exec_after_map_end = {exec_after_map_end}", player);
		}

		[ConsoleCommand("exec_after_map_end_once", "Executes a command when the map ends")]
		[RequiresPermissions("@css/rcon")]
		public void ConVarExecAfterMapEndOnce(CCSPlayerController? player, CommandInfo command)
		{
			string args = command.ArgString.Trim();
			if (string.IsNullOrEmpty(args))
			{
				ReplyToCommand($"exec_after_map_end_once = {exec_after_map_end_once}", player);
				return;
			}
			args = StripQuotes(args);
			exec_after_map_end_once = args;
			ReplyToCommand($"exec_after_map_end_once = {exec_after_map_end_once}", player);
		}

	}
}