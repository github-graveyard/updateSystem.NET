namespace updateSystemDotNet.Internal {
	/// <summary>
	/// Represents the thumbnail progress bar state.
	/// </summary>
	internal enum taskBarProgressState {
		/// <summary>
		/// No progress is displayed.
		/// </summary>
		NoProgress = 0,

		/// <summary>
		/// The progress is indeterminate (marquee).
		/// </summary>
		Indeterminate = 0x1,

		/// <summary>
		/// Normal progress is displayed.
		/// </summary>
		Normal = 0x2,

		/// <summary>
		/// An error occurred (red).
		/// </summary>
		Error = 0x4,

		/// <summary>
		/// The operation is paused (yellow).
		/// </summary>
		Paused = 0x8
	}
}