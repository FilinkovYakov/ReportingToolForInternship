namespace Mirantis.ReportingTool.BLL.Contracts
{
	using System;

	public interface ICustomLogger
    {
        void RecordError(Exception e);
		void RecordError(string message, Exception e);
		void RecordInfo(string info);
    }
}
